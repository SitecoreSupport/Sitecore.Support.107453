namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.SaveItem
{
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.ExperienceEditor.Speak.Server.Requests;
    using Sitecore.ExperienceEditor.Speak.Server.Responses;
    using Sitecore.ExperienceEditor.Switchers;
    using Sitecore.Globalization;
    using Sitecore.Pipelines;
    using Sitecore.Pipelines.Save;

    public class CallServerSavePipeline : PipelineProcessorRequest<Sitecore.ExperienceEditor.Speak.Server.Contexts.PageContext>
    {
        public override PipelineProcessorResponseValue ProcessRequest()
        {
            PipelineProcessorResponseValue value3;
            using (new EnforceVersionPresenceDisabler())
            {
                PipelineProcessorResponseValue value2 = new PipelineProcessorResponseValue();
                Pipeline pipeline = PipelineFactory.GetPipeline("saveUI");
                pipeline.ID = ShortID.Encode(ID.NewID);
                SaveArgs saveArgs = base.RequestContext.GetSaveArgs();
                using (new ClientDatabaseSwitcher(base.RequestContext.Item.Database))
                {
                    pipeline.Start(saveArgs);
                    value2.AbortMessage = Translate.Text(saveArgs.Error);
                    value3 = value2;
                }
            }
            return value3;
        }
    }
}
