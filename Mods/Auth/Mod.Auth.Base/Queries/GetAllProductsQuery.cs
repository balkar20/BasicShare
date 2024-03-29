// using MediatR;

using Core.Transfer;
using MediatR;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Queries;

public record GetAllUsersQuery(DataListPagingModel DataListPagingModel) : IRequest<ResponseResultWithData<List<UserModel>>>;