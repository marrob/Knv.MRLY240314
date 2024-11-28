namespace Knv.MRLY240314.Events
{
    class TestProgressAppEvent : IApplicationEvent
    {
        public string TotalSteps { get; set; }

        public string CurrentStepIndex { get; set; }

        public TestProgressAppEvent()
        {

        }
    }
}
