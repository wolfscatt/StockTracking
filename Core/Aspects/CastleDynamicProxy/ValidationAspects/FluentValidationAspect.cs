using Castle.DynamicProxy;
using Core.Aspects.CastleDynamicProxy.Interceptors;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.CastleDynamicProxy.ValidationAspects
{
    public class FluentValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }

        public override void OnBefore(IInvocation invocation)
        {
            Console.WriteLine("FluentValidationAspect is executing...");

            var validator = (IValidator)Activator.CreateInstance(_validatorType);  // ProductValidator'ı new'leyerek instance'ını oluşturuyoruz.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];   // ProductValidator olarak oluşturduğumuz validator'ın implemente ettiği AbstractValidator'ın generic argümanını alıyoruz.

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);  // Methodun argümanlarını dönüyoruz ve entityType'a eşit olanları alıyoruz.

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }

        }

    }
    
}
