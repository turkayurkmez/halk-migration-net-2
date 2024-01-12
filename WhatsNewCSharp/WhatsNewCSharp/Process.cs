
//File-scoped namespace: Dosya adı ve konumu üzerinden namespace'a dahil edilir.
namespace WhatsNewCSharp;

public class Process
{
    public void WriteToStream(string path)
    {
        DataTable dt = new DataTable();
        FileStream fileStream = new FileStream(path, FileMode.Create);

    }
}
