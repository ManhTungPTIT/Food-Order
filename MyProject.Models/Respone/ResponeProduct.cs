using MyProject.Models.Dtos;

namespace MyProject.Models.Respone;

public class ResponeProduct : ResponeResult
{
    public List<ProductDto> ProductDtos { get; set; }
}