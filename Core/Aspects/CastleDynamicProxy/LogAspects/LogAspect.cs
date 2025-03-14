using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.CastleDynamicProxy.LogAspects
{
    public class LogAspect : MethodInterception
    {
        private LoggerManager _loggerManager;

        public LogAspect(Type loggerManager)
        {
            if (loggerManager.BaseType != typeof(LoggerManager))
            {
                throw new Exception(AspectMessages.WrongLoggerType);
            }

            _loggerManager = (LoggerManager)Activator.CreateInstance(loggerManager);
        }

        public override void OnBefore(IInvocation invocation)
        {
            _loggerManager.Info(GetLogDetail(invocation));
        }
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}
