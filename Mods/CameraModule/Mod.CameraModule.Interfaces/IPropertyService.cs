using Mod.CameraModule.Models;

namespace Mod.CameraModule.Interfaces
{
    public interface IPropertyService
    {
        Task UpdateProperty(MainPropertyModel propertyModel);
    }
}