using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using Moq;
using RepositoryLayer.Interface;

namespace FundooNotesApp.Tests;

/// <summary>
/// Day-16: MSTest unit tests for NoteService.
/// Uses Moq to mock INoteRepository — no real database needed.
/// Tests cover all CRUD + Pin/Archive/Trash/Search operations.
/// </summary>
[TestClass]
public class NoteServiceTests
{
    // ── Test fixtures ─────────────────────────────────────────────────────────
    private Mock<INoteRepository>    _mockRepo     = null!;
    private Mock<ILogger<NoteService>> _mockLogger = null!;
    private Mock<IRabbitMqProducer>  _mockRabbitMq = null!;
    private NoteService              _service      = null!;

    private const int    UserId    = 1;
    private const string UserEmail = "test@example.com";

    [TestInitialize]
    public void Setup()
    {
        _mockRepo     = new Mock<INoteRepository>();
        _mockLogger   = new Mock<ILogger<NoteService>>();
        _mockRabbitMq = new Mock<IRabbitMqProducer>();
        _service      = new NoteService(_mockRepo.Object, _mockLogger.Object, _mockRabbitMq.Object);
    }

    // ── Helper to build a Note ────────────────────────────────────────────────
    private static Note MakeNote(int id = 1, string title = "Test Note") => new()
    {
        Id          = id,
        Title       = title,
        Description = "Sample description",
        UserId      = UserId,
        IsPinned    = false,
        IsArchived  = false,
        IsTrashed   = false,
        CreatedAt   = DateTime.UtcNow,
        UpdatedAt   = DateTime.UtcNow,
        NoteLabels  = new List<NoteLabel>()
    };

    // ─────────────────────────────────────────────────────────────────────────
    // 1. CreateNote — valid input returns NoteResponseDto
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    public async Task CreateNote_ValidInput_ReturnsNoteResponseDto()
    {
        // Arrange
        var dto  = new CreateNoteDto { Title = "My Note", Description = "Hello" };
        var note = MakeNote(1, "My Note");
        _mockRepo.Setup(r => r.CreateNoteAsync(It.IsAny<Note>())).ReturnsAsync(note);

        // Act
        var result = await _service.CreateNoteAsync(dto, UserId, UserEmail);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("My Note", result.Title);
        Assert.AreEqual(UserId, result.UserId);
        _mockRepo.Verify(r => r.CreateNoteAsync(It.IsAny<Note>()), Times.Once);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 2. GetAllNotes — returns list of user notes
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    public async Task GetAllNotes_ReturnsOnlyUserNotes()
    {
        // Arrange
        var notes = new List<Note> { MakeNote(1, "A"), MakeNote(2, "B") };
        _mockRepo.Setup(r => r.GetAllNotesByUserAsync(UserId)).ReturnsAsync(notes);

        // Act
        var result = await _service.GetAllNotesAsync(UserId);

        // Assert
        Assert.AreEqual(2, result.Count);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 3. GetNoteById — note not found throws KeyNotFoundException
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public async Task GetNoteById_NotFound_ThrowsKeyNotFoundException()
    {
        // Arrange — repo returns null (not found)
        _mockRepo.Setup(r => r.GetNoteByIdAsync(99)).ReturnsAsync((Note?)null);

        // Act — should throw
        await _service.GetNoteByIdAsync(99, UserId);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 4. GetNoteById — note belongs to different user throws KeyNotFoundException
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public async Task GetNoteById_WrongUser_ThrowsKeyNotFoundException()
    {
        // Arrange — note belongs to UserId=99
        var note = MakeNote(1, "Stolen");
        note.UserId = 99;
        _mockRepo.Setup(r => r.GetNoteByIdAsync(1)).ReturnsAsync(note);

        // Act — requesting with UserId=1 should throw
        await _service.GetNoteByIdAsync(1, UserId);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 5. UpdateNote — valid input updates and returns updated dto
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    public async Task UpdateNote_ValidInput_ReturnsUpdatedDto()
    {
        // Arrange
        var note    = MakeNote(1, "Old Title");
        var dto     = new UpdateNoteDto { Title = "New Title", Description = "Updated" };
        var updated = MakeNote(1, "New Title");
        _mockRepo.Setup(r => r.GetNoteByIdAsync(1)).ReturnsAsync(note);
        _mockRepo.Setup(r => r.UpdateNoteAsync(note)).ReturnsAsync(updated);

        // Act
        var result = await _service.UpdateNoteAsync(1, dto, UserId);

        // Assert
        Assert.AreEqual("New Title", result.Title);
        _mockRepo.Verify(r => r.UpdateNoteAsync(It.IsAny<Note>()), Times.Once);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 6. DeleteNote — not found throws KeyNotFoundException
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public async Task DeleteNote_NotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        _mockRepo.Setup(r => r.DeleteNoteAsync(99, UserId)).ReturnsAsync(false);

        // Act
        await _service.DeleteNoteAsync(99, UserId);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 7. TogglePin — sets IsPinned to true
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    public async Task TogglePin_SetsIsPinnedTrue()
    {
        // Arrange
        var note = MakeNote(1);
        note.IsPinned = true;  // simulate toggled state
        _mockRepo.Setup(r => r.TogglePinAsync(1, UserId)).ReturnsAsync(note);

        // Act
        var result = await _service.TogglePinAsync(1, UserId);

        // Assert
        Assert.IsTrue(result.IsPinned);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 8. ToggleArchive — archive also clears IsPinned
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    public async Task ToggleArchive_ArchivingUnpinsNote()
    {
        // Arrange — repository returns archived+unpinned note (business rule done in repo)
        var note = MakeNote(1);
        note.IsArchived = true;
        note.IsPinned   = false;
        _mockRepo.Setup(r => r.ToggleArchiveAsync(1, UserId)).ReturnsAsync(note);

        // Act
        var result = await _service.ToggleArchiveAsync(1, UserId);

        // Assert
        Assert.IsTrue(result.IsArchived);
        Assert.IsFalse(result.IsPinned);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 9. ToggleTrash — note not found throws KeyNotFoundException
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public async Task ToggleTrash_NotFound_ThrowsKeyNotFoundException()
    {
        _mockRepo.Setup(r => r.ToggleTrashAsync(99, UserId)).ReturnsAsync((Note?)null);

        await _service.ToggleTrashAsync(99, UserId);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 10. SearchNotes — empty query throws ArgumentException
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public async Task SearchNotes_EmptyQuery_ThrowsArgumentException()
    {
        await _service.SearchNotesAsync(UserId, "   ");
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 11. SearchNotes — valid query returns matching notes
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    public async Task SearchNotes_ValidQuery_ReturnsMatchingNotes()
    {
        // Arrange
        var notes = new List<Note> { MakeNote(1, "Work Note"), MakeNote(2, "Work Task") };
        _mockRepo.Setup(r => r.SearchNotesAsync(UserId, "work")).ReturnsAsync(notes);

        // Act
        var result = await _service.SearchNotesAsync(UserId, "work");

        // Assert
        Assert.AreEqual(2, result.Count);
    }
}
