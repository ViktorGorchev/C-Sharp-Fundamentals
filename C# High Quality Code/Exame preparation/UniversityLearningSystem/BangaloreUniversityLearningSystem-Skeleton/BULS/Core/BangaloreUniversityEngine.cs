namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Utilities;

    public class BangaloreUniversityEngine : IEngine
    {
        private readonly IBangaloreUniversityDate dataBase;

        public BangaloreUniversityEngine(IBangaloreUniversityDate dataBase)
        {
            this.dataBase = dataBase;
        }

        public void Run()
        {
            User user = null;
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == null || inputLine == "exit")
                {
                    break;
                }

                var route = new Route(inputLine);
                var controllerType =
                    Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .FirstOrDefault(type => type.Name == route.ControllerName);
                var ctrl = Activator.CreateInstance(controllerType, this.dataBase, user) as Controller;
                var act = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, act);
                try
                {
                    var view = act.Invoke(ctrl, @params) as IView;
                    Console.WriteLine(view.Display());
                    user = ctrl.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(
                p =>
                    {
                        if (p.ParameterType == typeof(int))
                        {
                            if (p.Name == "id")
                            {
                                return int.Parse(route.Parameters["courseId"]);
                            }

                            return int.Parse(route.Parameters[p.Name]);
                        }

                        return route.Parameters[p.Name];
                    }).ToArray();
        }
    }
}