using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenuRepository menuRepository)
        {
            Field<ListGraphType<MenuType>>("Menus").Resolve(context =>
            {
                return menuRepository.GetAllMenu();
            });

            Field<ListGraphType<MenuType>>("MenuByCategory").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId"})).Resolve(context =>
            {
                return menuRepository.GetMenuByCategoryId(context.GetArgument<int>("categoryId"));
            });
        }
    }
}
