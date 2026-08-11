using Xunit;
using static RestAssured.Dsl;

namespace ContactsApi;

public class RestAssuredApiTests
{
    private const string BaseUrl = "http://localhost:5000";

    [Fact]
    public void TestGetAllContacts_Returns200OK()
    {
        Given()
        .When()
            .Get($"{BaseUrl}/api/contacts")
        .Then()
            .StatusCode(200);
    }

    [Fact]
    public void TestGetContactById_Returns200OK()
    {
        Given()
        .When()
            .Get($"{BaseUrl}/api/contacts/1")
        .Then()
            .StatusCode(200);
    }

    [Fact]
    public void TestCreateContact_Returns201Created()
    {
        Given()
            .ContentType("application/json")
            .Body(new
            {
                firstName = "Vikram",
                lastName = "Singh",
                email = "vikram.singh@example.com",
                phoneNumber = "+91-9871234567",
                category = "Work"
            })
        .When()
            .Post($"{BaseUrl}/api/contacts")
        .Then()
            .StatusCode(201);
    }
}
