using RentHouse.DTO;

namespace RentHouse.IService
{
    //数据字典表
    public interface IIdNameService:IServiceMark
    {
        //类别名，名字
        long AddNew(string typeName, string name);
        //根据id获得类别名和名字
        IdNameDTO GetById(long id);

        //获取类别下所有idName 比如所有民族
        IdNameDTO[] GetAll(string typeName);

        void MarkDelete(long id);
    }
}
