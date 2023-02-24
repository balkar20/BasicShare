using BaseClientLibrary.Enums;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using ClientLibrary.Interfaces;
using IdentityProvider.Shared.Interfaces;

namespace ClientLibrary.Iterceptors;

public class MvvmInterceptor<TModel>: IInterceptor where TModel:IViewModel
{
    private readonly IBaseMvvmViewModel<TModel> _viewModel;
    
        public MvvmInterceptor(IBaseMvvmViewModel<TModel> viewModel)
        {
            _viewModel = viewModel;
        }
    
        public void Intercept(IInvocation invocation)
        {
            _viewModel.StatusType = StatusTypes.Loading;
            invocation.Proceed();
        }
}