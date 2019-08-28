namespace SongLyricVariationTracker
{
    public class Result
    {
        public int annotation_count { get; set; }
        public string api_path { get; set; }
        public string full_title { get; set; }
        public string header_image_thumbnail_url { get; set; }
        public string header_image_url { get; set; }
        public int id { get; set; }
        public int lyrics_owner_id { get; set; }
        public string lyrics_state { get; set; }
        public string path { get; set; }
        public int pyongs_count { get; set; }
        public string song_art_image_thumbnail_url { get; set; }
        public string song_art_image_url { get; set; }
        public Stats stats { get; set; }
        public string title { get; set; }
        public string title_with_featured { get; set; }
        public string url { get; set; }
        public PrimaryArtist primary_artist { get; set; }
    }
}