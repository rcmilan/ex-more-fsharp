namespace CSApi.DTOs
{
    public record SchoolDto(string Name, IEnumerable<CourseDto> Courses);
    public record CourseDto(string Name, IEnumerable<CoursePriceRangeDto> PriceRanges);
    public record CoursePriceRangeDto(int RangeFrom, int RangeTo, decimal Price);
}
