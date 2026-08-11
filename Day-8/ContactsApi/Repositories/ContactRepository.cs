using java.sql;
using ContactsApi.Models;

namespace ContactsApi.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly string _jdbcUrl;

    public ContactRepository(string jdbcUrl = "jdbc:h2:mem:contactsdb;DB_CLOSE_DELAY=-1")
    {
        _jdbcUrl = jdbcUrl;
        DriverManager.registerDriver(new org.h2.Driver());
    }

    private Connection CreateConnection()
    {
        return DriverManager.getConnection(_jdbcUrl, "sa", "");
    }

    public Task<IEnumerable<Contact>> GetAllAsync(string? search = null, string? category = null)
    {
        var contacts = new List<Contact>();
        using var conn = CreateConnection();

        var sql = "SELECT ID, FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, CATEGORY, CREATED_AT FROM CONTACTS WHERE 1=1";
        var parameters = new List<string>();

        if (!string.IsNullOrWhiteSpace(search))
        {
            sql += " AND (LOWER(FIRST_NAME) LIKE ? OR LOWER(LAST_NAME) LIKE ? OR LOWER(EMAIL) LIKE ? OR PHONE_NUMBER LIKE ?)";
            var searchPattern = $"%{search.Trim().ToLowerInvariant()}%";
            parameters.Add(searchPattern);
            parameters.Add(searchPattern);
            parameters.Add(searchPattern);
            parameters.Add(searchPattern);
        }

        if (!string.IsNullOrWhiteSpace(category) && !category.Equals("All", StringComparison.OrdinalIgnoreCase))
        {
            sql += " AND LOWER(CATEGORY) = ?";
            parameters.Add(category.Trim().ToLowerInvariant());
        }

        sql += " ORDER BY ID DESC;";

        using var pstmt = conn.prepareStatement(sql);
        for (int i = 0; i < parameters.Count; i++)
        {
            pstmt.setString(i + 1, parameters[i]);
        }

        using var rs = pstmt.executeQuery();
        while (rs.next())
        {
            contacts.Add(MapContact(rs));
        }

        return Task.FromResult<IEnumerable<Contact>>(contacts);
    }

    public Task<Contact?> GetByIdAsync(int id)
    {
        using var conn = CreateConnection();
        using var pstmt = conn.prepareStatement("SELECT ID, FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, CATEGORY, CREATED_AT FROM CONTACTS WHERE ID = ?;");
        pstmt.setInt(1, id);

        using var rs = pstmt.executeQuery();
        if (rs.next())
        {
            return Task.FromResult<Contact?>(MapContact(rs));
        }

        return Task.FromResult<Contact?>(null);
    }

    public Task<Contact> CreateAsync(Contact contact)
    {
        using var conn = CreateConnection();
        using var pstmt = conn.prepareStatement(@"
            INSERT INTO CONTACTS (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, CATEGORY, CREATED_AT)
            VALUES (?, ?, ?, ?, ?, NOW());
        ", Statement.RETURN_GENERATED_KEYS);

        pstmt.setString(1, contact.FirstName);
        pstmt.setString(2, contact.LastName);
        pstmt.setString(3, contact.Email);
        pstmt.setString(4, contact.PhoneNumber);
        pstmt.setString(5, contact.Category);

        pstmt.executeUpdate();

        using var keys = pstmt.getGeneratedKeys();
        if (keys.next())
        {
            contact.Id = keys.getInt(1);
        }

        return Task.FromResult(contact);
    }

    public async Task<Contact?> UpdateAsync(Contact contact)
    {
        var existing = await GetByIdAsync(contact.Id);
        if (existing is null) return null;

        using var conn = CreateConnection();
        using var pstmt = conn.prepareStatement(@"
            UPDATE CONTACTS 
            SET FIRST_NAME = ?,
                LAST_NAME = ?,
                EMAIL = ?,
                PHONE_NUMBER = ?,
                CATEGORY = ?
            WHERE ID = ?;
        ");

        pstmt.setString(1, contact.FirstName);
        pstmt.setString(2, contact.LastName);
        pstmt.setString(3, contact.Email);
        pstmt.setString(4, contact.PhoneNumber);
        pstmt.setString(5, contact.Category);
        pstmt.setInt(6, contact.Id);

        pstmt.executeUpdate();

        return await GetByIdAsync(contact.Id);
    }

    public Task<bool> DeleteAsync(int id)
    {
        using var conn = CreateConnection();
        using var pstmt = conn.prepareStatement("DELETE FROM CONTACTS WHERE ID = ?;");
        pstmt.setInt(1, id);

        var rowsAffected = pstmt.executeUpdate();
        return Task.FromResult(rowsAffected > 0);
    }

    private static Contact MapContact(ResultSet rs)
    {
        return new Contact
        {
            Id = rs.getInt("ID"),
            FirstName = rs.getString("FIRST_NAME"),
            LastName = rs.getString("LAST_NAME"),
            Email = rs.getString("EMAIL"),
            PhoneNumber = rs.getString("PHONE_NUMBER"),
            Category = rs.getString("CATEGORY"),
            CreatedAt = DateTime.UtcNow
        };
    }
}
