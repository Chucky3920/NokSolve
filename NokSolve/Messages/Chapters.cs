// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using System.Text.Json.Serialization;

public class Chapter
    {
        [JsonPropertyName("hierarchyID")]
        public int HierarchyID { get; set; }

        [JsonPropertyName("parent")]
        public int Parent { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("series")]
        public int Series { get; set; }

        [JsonPropertyName("max_level")]
        public int MaxLevel { get; set; }

        [JsonPropertyName("published")]
        public int Published { get; set; }

        [JsonPropertyName("updated_by")]
        public int UpdatedBy { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("depth")]
        public int Depth { get; set; }

        [JsonPropertyName("path")]
        public int Path { get; set; }

        [JsonPropertyName("isHidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("user_progress")]
        public List<object> UserProgress { get; set; }

        [JsonPropertyName("sections")]
        public List<object> Sections { get; set; }

        [JsonPropertyName("parts")]
        public List<Part> Parts { get; set; }
    }

    public class Content
    {
        [JsonPropertyName("chapters")]
        public List<Chapter> Chapters { get; set; }
    }

    public class Lesson
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("html")]
        public string Html { get; set; }
    }

    public class Part
    {
        [JsonPropertyName("hierarchyID")]
        public int HierarchyID { get; set; }

        [JsonPropertyName("parent")]
        public int Parent { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("series")]
        public int Series { get; set; }

        [JsonPropertyName("max_level")]
        public int MaxLevel { get; set; }

        [JsonPropertyName("published")]
        public int Published { get; set; }

        [JsonPropertyName("updated_by")]
        public int UpdatedBy { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("depth")]
        public int Depth { get; set; }

        [JsonPropertyName("path")]
        public double Path { get; set; }

        [JsonPropertyName("isHidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("user_progress")]
        public List<object> UserProgress { get; set; }

        [JsonPropertyName("sections")]
        public List<object> Sections { get; set; }

        [JsonPropertyName("subParts")]
        public List<SubPart> SubParts { get; set; }
    }

    public class Pivot
    {
        [JsonPropertyName("hierarchy_id")]
        public int HierarchyId { get; set; }

        [JsonPropertyName("section_id")]
        public int SectionId { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("content")]
        public Content Content { get; set; }

        [JsonPropertyName("favorites")]
        public List<object> Favorites { get; set; }

        [JsonPropertyName("readable_course")]
        public string ReadableCourse { get; set; }

        [JsonPropertyName("formulas_link")]
        public string FormulasLink { get; set; }

        [JsonPropertyName("product_info")]
        public string ProductInfo { get; set; }
    }

    public class Section
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lesson_id")]
        public int LessonId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("pivot")]
        public Pivot Pivot { get; set; }

        [JsonPropertyName("lesson")]
        public Lesson Lesson { get; set; }

        [JsonPropertyName("section_assignment_relations")]
        public List<SectionAssignmentRelation> SectionAssignmentRelations { get; set; }
    }

    public class SectionAssignmentRelation
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("section_id")]
        public int SectionId { get; set; }

        [JsonPropertyName("assignment_id")]
        public int AssignmentId { get; set; }

        [JsonPropertyName("assignment_name")]
        public int AssignmentName { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }
    }

    public class SubPart
    {
        [JsonPropertyName("hierarchyID")]
        public int HierarchyID { get; set; }

        [JsonPropertyName("parent")]
        public int Parent { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("series")]
        public int Series { get; set; }

        [JsonPropertyName("max_level")]
        public int MaxLevel { get; set; }

        [JsonPropertyName("published")]
        public int Published { get; set; }

        [JsonPropertyName("updated_by")]
        public int? UpdatedBy { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("depth")]
        public int Depth { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("isHidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("user_progress")]
        public List<UserProgress> UserProgress { get; set; }

        [JsonPropertyName("sections")]
        public List<Section> Sections { get; set; }

        [JsonPropertyName("children")]
        public List<object> Children { get; set; }
    }

    public class UserProgress
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userID")]
        public int UserID { get; set; }

        [JsonPropertyName("hierarchyID")]
        public int HierarchyID { get; set; }

        [JsonPropertyName("progress")]
        public int Progress { get; set; }

        [JsonPropertyName("level_progress")]
        public List<double> LevelProgress { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

