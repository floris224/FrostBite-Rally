using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Locomotion;
using System.Collections.Generic;

public class PlayerConfiguration : MonoBehaviour {

    [Header("Hand Visuals")]

    [SerializeField]
    #if UNITY_EDITOR
    [Help("Hier kan je aangeven wat voor soort visuele representatie je wilt gebruiken voor je controllers. Om functionaliteit te behouden zijn de controllers nog wel aanwezig, slechts de 'SkinnedMeshRenderer' components worden enabled/disabled.\n\n- Controller (0): Een virtuele Meta Quest 2 controller\n- Synthetic Hand (1): Een virtuele (pose-able) hand\n- Dot (2): Een kleine witte sphere op de positie van interactie\n- Controller and Synthetic Hand (3): Combinatie van bovenstaande Controller (1) en Synthetic Hand (2)\n- Controller and Dot (4): Combinatie van bovenstaande Controller (1) en Dot (3)\n- Synthetic Hand and Dot (5): Combinatie van bovenstaande Synthetic Hand (2) en Dot (3)\n- All (6): Combinatie van bovenstaande Controller (1), Synthetic Hand (2) en Dot (3)\n- None (7): Geen visuele representatie.\n\nJe kan de controllers ook tijdens runtime aanpassen. Dit kan je doen door de publieke functies 'SetHandVisuals, SetHandVisualLeft' of 'SetHandVisualRight' op dit script aan te roepen. Als parameter(s) geef je de enumerator index van 'Controllers' mee (getal achter de opties hierboven).", UnityEditor.MessageType.Info)]
    #endif

    public Controllers leftHand;
    public Controllers rightHand;
    public enum Controllers { Controller = 0, SyntheticHand = 1, Dot = 2, ControllerAndSyntheticHand = 3, ControllerAndDot = 4, SyntheticHandAndDot = 5, All = 6, None = 7 }

    [SerializeField]
    #if UNITY_EDITOR
    [Help("Dit zijn referenties voor de 'Hand Visuals'.\nNiet veranderen tenzij je weet wat je doet!", UnityEditor.MessageType.Warning)]
    #endif

    public SkinnedMeshRenderer controllerLeft;
    public SkinnedMeshRenderer controllerRight;
    public SkinnedMeshRenderer syntheticHandLeft;
    public SkinnedMeshRenderer syntheticHandRight;
    public MeshRenderer dotLeft;
    public MeshRenderer dotRight;

    private int handVisualLeftIndex;
    private int handVisualRightIndex;

    [Header("Control Scheme")]

    [SerializeField]
    #if UNITY_EDITOR
    [Help("Dit zijn referenties voor de 'Control Scheme'.\nNiet veranderen tenzij je weet wat je doet!", UnityEditor.MessageType.Warning)]
    #endif

    public LocomotionEventsConnection _locomotionEventsConnectionLeft;
    public LocomotionEventsConnection _locomotionEventsConnectionRight;
    public UnityEngine.Object TeleportControllerInteractorLeft;
    public UnityEngine.Object TeleportControllerInteractorRight;
    public UnityEngine.Object ControllerTurnerInteractorLeft;
    public UnityEngine.Object ControllerTurnerInteractorRight;
    public BestSelectInteractorGroup _bestSelectInteractorGroupLeft;
    public BestSelectInteractorGroup _bestSelectInteractorGroupRight;
    public TeleportInteractor _teleportInteractorLeft;
    public TeleportInteractor _teleportInteractorRight;
    public LocomotionAxisTurnerInteractor _locomotionAxisTurnerInteractorLeft;
    public LocomotionAxisTurnerInteractor _locomotionAxisTurnerInteractorRight;



    private void Start() {
        // Hand Visuals Initialization
        handVisualLeftIndex = (int)leftHand;
        handVisualRightIndex = (int)rightHand;
        SetHandVisuals();

        /*
        // Control Scheme Initialization
        List<UnityEngine.Object> broadcastersLeft = new List<UnityEngine.Object>();
        broadcastersLeft.Add(TeleportControllerInteractorLeft);
        broadcastersLeft.Add(ControllerTurnerInteractorLeft);
        _locomotionEventsConnectionLeft.InjectBroadcasters(broadcastersLeft.ConvertAll(b => b as ILocomotionEventBroadcaster));
        List<UnityEngine.Object> broadcastersRight = new List<UnityEngine.Object>();
        _locomotionEventsConnectionRight.InjectBroadcasters(broadcastersRight.ConvertAll(b => b as ILocomotionEventBroadcaster));

        List<IInteractor> interactorsLeft = new List<IInteractor>();
        interactorsLeft.Add(_teleportInteractorLeft);
        interactorsLeft.Add(_locomotionAxisTurnerInteractorLeft);
        List<IInteractor> interactorsRight= new List<IInteractor>();
        _bestSelectInteractorGroupLeft.InjectInteractors(interactorsLeft);
        _bestSelectInteractorGroupLeft.InjectInteractors(interactorsRight);
        */

    }

    private void SetHandVisuals () {
        SetHandVisuals(handVisualLeftIndex, handVisualRightIndex);
    }

    public void SetHandVisuals (int controllerIndex) {
        SetHandVisualLeft(controllerIndex);
        SetHandVisualRight(controllerIndex);
    }

    public void SetHandVisuals (int controllerIndexLeft, int controllerIndexRight) {
        SetHandVisualLeft(controllerIndexLeft);
        SetHandVisualRight(controllerIndexRight);
    }

    public void SetHandVisualLeft(int controllerIndex) {
        switch (controllerIndex) {
            case 0: // Controller
                controllerLeft.enabled = true;
                syntheticHandLeft.enabled = false;
                dotLeft.enabled = false;
                break;
            case 1: // Synthetic Hand
                controllerLeft.enabled = false;
                syntheticHandLeft.enabled = true;
                dotLeft.enabled = false;
                break;
            case 2: // Dot
                controllerLeft.enabled = false;
                syntheticHandLeft.enabled = false;
                dotLeft.enabled = true;
                break;
            case 3: // Controller and Synthetic Hand
                controllerLeft.enabled = true;
                syntheticHandLeft.enabled = true;
                dotLeft.enabled = false;
                break;
            case 4: // Controller and Dot
                controllerLeft.enabled = true;
                syntheticHandLeft.enabled = false;
                dotLeft.enabled = true;
                break;
            case 5: // Synthetic Hand and Dot
                controllerLeft.enabled = false;
                syntheticHandLeft.enabled = true;
                dotLeft.enabled = true;
                break;
            case 6: // All
                controllerLeft.enabled = true;
                syntheticHandLeft.enabled = true;
                dotLeft.enabled = true;
                break;
            case 7: // None
                controllerLeft.enabled = false;
                syntheticHandLeft.enabled = false;
                dotLeft.enabled = false;
                break;
        }
    }

    public void SetHandVisualRight (int controllerIndex) {
        switch (controllerIndex) {
            case 0: // Controller
                controllerRight.enabled = true;
                syntheticHandRight.enabled = false;
                dotRight.enabled = false;
                break;
            case 1: // Synthetic Hand
                controllerRight.enabled = false;
                syntheticHandRight.enabled = true;
                dotRight.enabled = false;
                break;
            case 2: // Dot
                controllerRight.enabled = false;
                syntheticHandRight.enabled = false;
                dotRight.enabled = true;
                break;
            case 3: // Controller and Synthetic Hand
                controllerRight.enabled = true;
                syntheticHandRight.enabled = true;
                dotRight.enabled = false;
                break;
            case 4: // Controller and Dot
                controllerRight.enabled = true;
                syntheticHandRight.enabled = false;
                dotRight.enabled = true;
                break;
            case 5: // Synthetic Hand and Dot
                controllerRight.enabled = false;
                syntheticHandRight.enabled = true;
                dotRight.enabled = true;
                break;
            case 6: // All
                controllerRight.enabled = true;
                syntheticHandRight.enabled = true;
                dotRight.enabled = true;
                break;
            case 7: // None
                controllerRight.enabled = false;
                syntheticHandRight.enabled = false;
                dotRight.enabled = false;
                break;
        }
    }

    public void SetNextHandVisualLeft () {
        switch (handVisualLeftIndex) {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                handVisualLeftIndex++;
                break;
            default:
                handVisualLeftIndex = 0;
                break;
        }
        SetHandVisualLeft(handVisualLeftIndex);
    }

    public void SetNextHandVisualRight () {
        switch (handVisualRightIndex) {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                handVisualRightIndex++;
                break;
            default:
                handVisualRightIndex = 0;
                break;
        }
        SetHandVisualRight(handVisualRightIndex);
    }
}