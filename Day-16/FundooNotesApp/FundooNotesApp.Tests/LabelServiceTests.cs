using BusinessLayer.Service;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using Moq;
using RepositoryLayer.Interface;

namespace FundooNotesApp.Tests;

/// <summary>
/// Day-16: MSTest unit tests for LabelService.
/// Uses Moq to mock ILabelRepository — no real database needed.
/// Tests cover CRUD operations and ownership validation.
/// </summary>
[TestClass]
public class LabelServiceTests
{
    // ── Test fixtures ─────────────────────────────────────────────────────────
    private Mock<ILabelRepository>     _mockRepo   = null!;
    private Mock<ILogger<LabelService>> _mockLogger = null!;
    private LabelService               _service    = null!;

    private const int UserId = 1;

    [TestInitialize]
    public void Setup()
    {
        _mockRepo   = new Mock<ILabelRepository>();
        _mockLogger = new Mock<ILogger<LabelService>>();
        _service    = new LabelService(_mockRepo.Object, _mockLogger.Object);
    }

    // ── Helper ────────────────────────────────────────────────────────────────
    private static Label MakeLabel(int id = 1, string name = "Work") => new()
    {
        Id        = id,
        Name      = name,
        Color     = "#FF5733",
        UserId    = UserId,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        NoteLabels = new List<NoteLabel>()
    };

    // ─────────────────────────────────────────────────────────────────────────
    // 1. CreateLabel — valid input returns LabelResponseDto
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    public async Task CreateLabel_ValidInput_ReturnsLabelResponseDto()
    {
        // Arrange
        var dto   = new CreateLabelDto { Name = "Work", Color = "#FF5733" };
        var label = MakeLabel(1, "Work");
        _mockRepo.Setup(r => r.CreateLabelAsync(It.IsAny<Label>())).ReturnsAsync(label);

        // Act
        var result = await _service.CreateLabelAsync(dto, UserId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Work",    result.Name);
        Assert.AreEqual("#FF5733", result.Color);
        Assert.AreEqual(UserId,    result.UserId);
        _mockRepo.Verify(r => r.CreateLabelAsync(It.IsAny<Label>()), Times.Once);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 2. GetAllLabels — returns all user labels
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    public async Task GetAllLabels_ReturnsUserLabels()
    {
        // Arrange
        var labels = new List<Label> { MakeLabel(1, "Work"), MakeLabel(2, "Personal") };
        _mockRepo.Setup(r => r.GetAllLabelsByUserAsync(UserId)).ReturnsAsync(labels);

        // Act
        var result = await _service.GetAllLabelsAsync(UserId);

        // Assert
        Assert.AreEqual(2, result.Count);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 3. GetLabelById — label not found throws KeyNotFoundException
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public async Task GetLabelById_NotFound_ThrowsKeyNotFoundException()
    {
        _mockRepo.Setup(r => r.GetLabelByIdAsync(99)).ReturnsAsync((Label?)null);

        await _service.GetLabelByIdAsync(99, UserId);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 4. GetLabelById — wrong user throws KeyNotFoundException
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public async Task GetLabelById_WrongUser_ThrowsKeyNotFoundException()
    {
        var label = MakeLabel(1, "Other");
        label.UserId = 99;  // belongs to different user
        _mockRepo.Setup(r => r.GetLabelByIdAsync(1)).ReturnsAsync(label);

        await _service.GetLabelByIdAsync(1, UserId);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 5. UpdateLabel — valid update returns updated dto
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    public async Task UpdateLabel_ValidInput_ReturnsUpdatedDto()
    {
        // Arrange
        var existing = MakeLabel(1, "Old");
        var dto      = new UpdateLabelDto { Name = "New", Color = "#AABBCC" };
        var updated  = MakeLabel(1, "New");
        updated.Color = "#AABBCC";

        _mockRepo.Setup(r => r.GetLabelByIdAsync(1)).ReturnsAsync(existing);
        _mockRepo.Setup(r => r.UpdateLabelAsync(existing)).ReturnsAsync(updated);

        // Act
        var result = await _service.UpdateLabelAsync(1, dto, UserId);

        // Assert
        Assert.AreEqual("New",    result.Name);
        Assert.AreEqual("#AABBCC", result.Color);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 6. DeleteLabel — not owned throws KeyNotFoundException
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public async Task DeleteLabel_NotOwner_ThrowsKeyNotFoundException()
    {
        _mockRepo.Setup(r => r.DeleteLabelAsync(1, UserId)).ReturnsAsync(false);

        await _service.DeleteLabelAsync(1, UserId);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 7. AssignLabelToNote — not found throws KeyNotFoundException
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public async Task AssignLabelToNote_InvalidIds_ThrowsKeyNotFoundException()
    {
        _mockRepo.Setup(r => r.AssignLabelToNoteAsync(99, 99, UserId)).ReturnsAsync(false);

        await _service.AssignLabelToNoteAsync(99, 99, UserId);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 8. AssignLabelToNote — success returns true
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    public async Task AssignLabelToNote_ValidIds_ReturnsTrue()
    {
        _mockRepo.Setup(r => r.AssignLabelToNoteAsync(1, 1, UserId)).ReturnsAsync(true);

        var result = await _service.AssignLabelToNoteAsync(1, 1, UserId);

        Assert.IsTrue(result);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 9. RemoveLabelFromNote — not assigned throws KeyNotFoundException
    // ─────────────────────────────────────────────────────────────────────────
    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public async Task RemoveLabelFromNote_NotAssigned_ThrowsKeyNotFoundException()
    {
        _mockRepo.Setup(r => r.RemoveLabelFromNoteAsync(1, 1, UserId)).ReturnsAsync(false);

        await _service.RemoveLabelFromNoteAsync(1, 1, UserId);
    }
}
