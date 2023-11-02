using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Base.DataBase.Interfaces;

public interface IEntity
{
    public Guid Id { get; set; } 
}