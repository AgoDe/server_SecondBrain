using Microsoft.AspNetCore.Mvc.ModelBinding;
using SecondBrain.Models;

namespace SecondBrain.Customization.ModelBinders;

public class QueryInputModelBinder : IModelBinder
{

    public QueryInputModelBinder()
    {
    }
    
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {

        // recupero i valori tramite ai value provider
        string search = bindingContext.ValueProvider.GetValue("Search").FirstValue ?? "";
        string orderBy = bindingContext.ValueProvider.GetValue("OrderBy").FirstValue ?? "Id";
        bool ascending = Convert.ToBoolean(bindingContext.ValueProvider.GetValue("ascending").FirstValue);
        var pageNumber = Convert.ToInt32(bindingContext.ValueProvider.GetValue("pagenumber").FirstValue);
        var pageSize = Convert.ToInt32(bindingContext.ValueProvider.GetValue("pagesize").FirstValue);
        
        // creo l'istanza del ListInputModel
        var inputModel = new QueryInputModel(search, orderBy, ascending, pageNumber, pageSize);
        
        // Imposto il risultato per notificare che la creazione è avvenuta con successo
        bindingContext.Result = ModelBindingResult.Success(inputModel);

        // // Restitutisco un task completato
        return Task.CompletedTask;
    }


    
} 