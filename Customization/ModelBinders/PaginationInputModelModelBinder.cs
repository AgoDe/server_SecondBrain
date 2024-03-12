using Microsoft.AspNetCore.Mvc.ModelBinding;
using SecondBrain.Models;
using SecondBrain.Models.Dto;
using SecondBrain.Models.InputModel;

namespace SecondBrain.Customization.ModelBinders;

public class PaginationInputModelModelBinder : IModelBinder
{

    public PaginationInputModelModelBinder()
    {
    }
    
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {

        // recupero i valori tramite ai value provider
        var pageNumber = Convert.ToInt32(bindingContext.ValueProvider.GetValue("pagenumber").FirstValue);
        var pageSize = Convert.ToInt32(bindingContext.ValueProvider.GetValue("pagesize").FirstValue);
        
        // creo l'istanza del ListInputModel
        var inputModel = new PaginationInputModel(pageNumber, pageSize);
        
        // Imposto il risultato per notificare che la creazione è avvenuta con successo
        bindingContext.Result = ModelBindingResult.Success(inputModel);

        // // Restitutisco un task completato
        return Task.CompletedTask;
    }


    
} 