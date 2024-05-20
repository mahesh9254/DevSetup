namespace WebHook.Payloods
{
    public class BitbucketPayload
    {
        public Repository repository { get; set; }
        public Actor actor { get; set; }
        public Commit_Status commit_status { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Actor
    {
        public string display_name { get; set; }
        public Links links { get; set; }
        public string type { get; set; }
        public string uuid { get; set; }
        public string username { get; set; }
    }

    public class Approve
    {
        public string href { get; set; }
    }

    public class Author
    {
        public string type { get; set; }
        public string raw { get; set; }
        public User user { get; set; }
    }

    public class Avatar
    {
        public string href { get; set; }
    }

    public class Comments
    {
        public string href { get; set; }
    }

    public class Commit
    {
        public string type { get; set; }
        public string hash { get; set; }
        public DateTime date { get; set; }
        public Author author { get; set; }
        public string message { get; set; }
        public Links links { get; set; }
        public string href { get; set; }
    }

    public class Commit_Status
    {
        public string key { get; set; }
        public string type { get; set; }
        public string state { get; set; }
        public string name { get; set; }
        public string refname { get; set; }
        public Commit commit { get; set; }
        public string url { get; set; }
        public Repository repository { get; set; }
        public string description { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
        public Links links { get; set; }
    }

    public class Diff
    {
        public string href { get; set; }
    }

    public class Html
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public Html html { get; set; }
        public Avatar avatar { get; set; }
        public Diff diff { get; set; }
        public Approve approve { get; set; }
        public Comments comments { get; set; }
        public Statuses statuses { get; set; }
        public Patch patch { get; set; }
        public Commit commit { get; set; }
    }

    public class Owner
    {
        public string display_name { get; set; }
        public Links links { get; set; }
        public string type { get; set; }
        public string uuid { get; set; }
        public string username { get; set; }
    }

    public class Patch
    {
        public string href { get; set; }
    }

    public class Project
    {
        public string type { get; set; }
        public string key { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public Links links { get; set; }
    }

    public class Repository
    {
        public string type { get; set; }
        public string full_name { get; set; }
        public Links links { get; set; }
        public string name { get; set; }
        public string scm { get; set; }
        public object website { get; set; }
        public Owner owner { get; set; }
        public Workspace workspace { get; set; }
        public bool is_private { get; set; }
        public Project project { get; set; }
        public string uuid { get; set; }
        public object parent { get; set; }
    }

  

    public class Self
    {
        public string href { get; set; }
    }

    public class Statuses
    {
        public string href { get; set; }
    }

    public class User
    {
        public string display_name { get; set; }
        public Links links { get; set; }
        public string type { get; set; }
        public string uuid { get; set; }
        public string account_id { get; set; }
        public string nickname { get; set; }
    }

    public class Workspace
    {
        public string type { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public Links links { get; set; }
    }


}
