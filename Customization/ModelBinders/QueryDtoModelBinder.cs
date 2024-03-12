using Microsoft.AspNetCore.Mvc.ModelBinding;
using SecondBrain.Models;
using SecondBrain.Models.Dto;

namespace SecondBrain.Customization.ModelBinders;

public class QueryDtoModelBinder : IModelBinder
{

    public QueryDtoModelBinder()
    {
    }
    
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {

        // recupero i valori tramite ai value provider
        string search = bindingContext.ValueProvider.GetValue("Search").FirstValue ?? "";
        string orderBy = bindingContext.ValueProvider.GetValue("OrderBy").FirstValue ?? "Id";
        bool ascending = Convert.ToBoolean(bindingContext.ValueProvider.GetValue("ascending").FirstValue);
        DateTime dateFrom = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("datefrom").FirstValue);
        DateTime dateTo = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("dateto").FirstValue);
        bool isActive = Convert.ToBoolean(bindingContext.ValueProvider.GetValue("isactive").FirstValue);
        
        // creo l'istanza del ListInputModel
        var inputModel = new QueryDto(search, orderBy, ascending, dateFrom, dateTo, isActive);
        
        // Imposto il risultato per notificare che la creazione è avvenuta con successo
        bindingContext.Result = ModelBindingResult.Success(inputModel);

        // // Restitutisco un task completato
        return Task.CompletedTask;
    }


    
} 