using BeatSaberMarkupLanguage;
using SiraUtil.Logging;
using HMUI;
using System;

namespace SessionCombo.FlowCoordinators
{
    internal class SessionComboFlowCoordinator : FlowCoordinator
    {
        private SiraLog _siraLog;
        private MainFlowCoordinator _mainFlowCoordinator;

        public void Construct(MainFlowCoordinator mainFlowCoordinator, SiraLog siraLog)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _siraLog = siraLog;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            try
            {
                if (firstActivation)
                {
                    SetTitle("SessionCombo");
                    showBackButton = true;
                    //ProvideInitialViewControllers( /* Put your ViewControllers here! */);
                }
            }
            catch (Exception ex)
            {
                _siraLog.Error(ex);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _mainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}