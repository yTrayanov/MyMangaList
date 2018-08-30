using AutoMapper;
using MyMangaList.Mapper.Mapping;

namespace MyMangaList.Test.Mocks
{
    public static class MockAutoMapper
    {
        public static IMapper GetMapper()
        {

          AutoMapper.Mapper.Initialize(config => config.AddProfile<AuthoMapperProfile>());
            return AutoMapper.Mapper.Instance;
        }
    }
}
