using java.sql;

namespace ContactsApi.Data;

public class DatabaseInitializer
{
    private readonly string _jdbcUrl;

    public DatabaseInitializer(string jdbcUrl = "jdbc:h2:mem:contactsdb;DB_CLOSE_DELAY=-1")
    {
        _jdbcUrl = jdbcUrl;
        DriverManager.registerDriver(new org.h2.Driver());
    }

    public Task InitializeAsync()
    {
        using var conn = DriverManager.getConnection(_jdbcUrl, "sa", "");
        using var stmt = conn.createStatement();

        stmt.execute(@"
            CREATE TABLE IF NOT EXISTS CONTACTS (
                ID INT AUTO_INCREMENT PRIMARY KEY,
                FIRST_NAME VARCHAR(100) NOT NULL,
                LAST_NAME VARCHAR(100) NOT NULL,
                EMAIL VARCHAR(255) NOT NULL,
                PHONE_NUMBER VARCHAR(50) NOT NULL,
                CATEGORY VARCHAR(50) NOT NULL,
                CREATED_AT TIMESTAMP NOT NULL
            );
        ");

        // Seed initial data if table is empty
        var rs = stmt.executeQuery("SELECT COUNT(*) AS CNT FROM CONTACTS");
        var count = 0;
        if (rs.next())
        {
            count = rs.getInt("CNT");
        }

        if (count == 0)
        {
            var seedData = new[]
            {
                ("Abhishek", "Pathak", "abhishek.pathak@bridgelabz.com", "+91-9876543210", "Work"),
                ("Ananya", "Sharma", "ananya.sharma@example.com", "+91-9123456789", "Personal"),
                ("Rahul", "Verma", "rahul.verma@techcorp.io", "+91-9988776655", "Work"),
                ("Priya", "Patel", "priya.patel@family.org", "+91-9554433221", "Family")
            };

            foreach (var (firstName, lastName, email, phone, category) in seedData)
            {
                using var pstmt = conn.prepareStatement(@"
                    INSERT INTO CONTACTS (FIRST_NAME, LAST_NAME, EMAIL, PHONE_NUMBER, CATEGORY, CREATED_AT)
                    VALUES (?, ?, ?, ?, ?, NOW());
                ");
                pstmt.setString(1, firstName);
                pstmt.setString(2, lastName);
                pstmt.setString(3, email);
                pstmt.setString(4, phone);
                pstmt.setString(5, category);
                pstmt.executeUpdate();
            }
        }

        return Task.CompletedTask;
    }
}
