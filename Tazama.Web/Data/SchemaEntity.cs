namespace Tazama.Web.Data;

public class SchemaEntity
{
    /// <summary>
    /// The unique identifier for the schema (could be a GUID).
    /// </summary>
    public string SchemaId { get; set; }

    /// <summary>
    /// The unique schema key provided to the user.
    /// </summary>
    public string SchemaKey { get; set; }

    /// <summary>
    /// The JSON schema content.
    /// </summary>
    public string SchemaContent { get; set; }

    /// <summary>
    /// The date and time when the schema was uploaded.
    /// </summary>
    public DateTime DateUploaded { get; set; }

    /// <summary>
    /// The identifier for the user who uploaded the schema (optional).
    /// </summary>
    public string UserId { get; set; }
}
