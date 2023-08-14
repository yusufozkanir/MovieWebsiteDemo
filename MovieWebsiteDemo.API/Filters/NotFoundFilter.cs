using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;
using MovieWebsiteDemo.Core.Services;

namespace MovieWebsiteDemo.API.Filters
{
    //public class NotFoundFilter<Entity, Dto> : IAsyncActionFilter where Entity : BaseEntity where Dto : class
    //{
    //    private readonly IGenericService<Entity, Dto> _service;

    //    public NotFoundFilter(IGenericService<Entity, Dto> service)
    //    {
    //        _service = service;
    //    }

    //    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    {
    //        var idValue = context.ActionArguments.Values.FirstOrDefault();
    //        if (idValue == null)
    //        {
    //            await next.Invoke();
    //            return;
    //        }

    //        var id = (int)idValue;
    //        var anyEntity = await _service.AnyAsync(x => x.Id == id);

    //        if (anyEntity)
    //        {
    //            await next.Invoke();
    //            return;
    //        }
    //        context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(Entity).Name}({id}) not found"));

    //    }
    //}
}
