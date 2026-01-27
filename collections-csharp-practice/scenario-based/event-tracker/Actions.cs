using System;

public class UserActions
{
    [AuditTrail("User login action")]
    public void Login() { }

    [AuditTrail("User logout action")]
    public void Logout() { }

    public void Browse() { } // Not audited
}

public class FileActions
{
    [AuditTrail("File upload")]
    public void UploadFile() { }

    [AuditTrail("File delete")]
    public void DeleteFile() { }

    public void DownloadFile() { } // Not audited
}
