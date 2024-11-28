namespace Knv.MRLY240314.Events
{
    class TestCompletedAppEvent : IApplicationEvent
    {
        public string TestResult { get; set; }
        public string ElapsedTime { get; set; }
        public string TotalSteps { get; set; }
        public string TotalPassed { get; set; }
        public string TotalFailed { get; set; }

        public TestCompletedAppEvent()
        {
        }
    }
}