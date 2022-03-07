using SpecFlowPOC.Specs.Constants;

namespace SpecFlowPOC.Specs.Hooks
{
    [Binding]
    public class RunHooks
    {
        //The following example is for good example of context injection while not using static class
        //public MachineConfig _machineConfig;
        //public ProjectConstants _projectConstants;
        public RunHooks(/*MachineConfig machineConfig,*/
                              /*ProjectConstants projectConstants*/)
        {
            //_machineConfig = machineConfig;
            //_projectConstants = projectConstants;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //MachineConfig _machineConfig = new MachineConfig();
            //ProjectConstants _projectConstants = new ProjectConstants();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {

        }
    }
}
