// using Hackaton_DW_2024.Data.Config;
// using Hackaton_DW_2024.Data.Dto.Customization;
// using Hackaton_DW_2024.Data.Package;
// using Microsoft.EntityFrameworkCore;
//
// namespace Hackaton_DW_2024.Data.DataSources.CustomizationItems;
//
// public class EfCustomizationItemsDataSource : EntityFrameworkDataSource, ICustomizationItemsDataSource
// {
//     DbSet<AchievementDto> _achievements;
//
//
//     public EfAchievementsDataSource(ApplicationContext context) : base(context)
//     {
//         _achievements = context.Achievements;
//     }
//
//     public CustomizationItemDto? SelectById(int id) => Items.FirstOrDefault(dto => dto.Id == id);
//
//     public List<CustomizationItemDto> SelectAll() => Items.ToList();
//     public void InsertOne(CustomizationItemDto dto)
//     {
//         Items.Add(dto);
//         SaveChanges();
//     }
//
//     public void DeleteById(int id)
//     {
//         var deleteTarget = Items.FirstOrDefault(dto => dto.Id == id);
//         Items.Remove(deleteTarget);
//         SaveChanges();
//     }
// }