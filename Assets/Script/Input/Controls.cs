//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/Player.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""CombatLevel"",
            ""id"": ""51ba6249-b9f6-4477-b292-5c9ee2f9ec4d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b1999c04-21d4-4392-af7f-014dd3ac4b58"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""c1d602fb-4b96-4438-98da-10ae3a6c8e63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""722c39c4-551b-44c4-ad4a-d672b92f2900"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skill"",
                    ""type"": ""Button"",
                    ""id"": ""1439fd4c-2983-4100-bf44-f0bceb224df9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Heal"",
                    ""type"": ""Button"",
                    ""id"": ""1be06068-cc5c-4d25-9cfc-6cbff46ebd60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ESC"",
                    ""type"": ""Button"",
                    ""id"": ""d67e5708-03b1-45a6-b0a7-66fc28959a5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SanCheck"",
                    ""type"": ""Button"",
                    ""id"": ""72cb478d-a3d5-469a-965c-ced846189445"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""3ec2746a-7b73-4839-8c8c-eea82fddebf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7e1fdc39-abbb-4647-aeba-442bca27da2a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1fa9331a-60d1-4308-939c-51aa6e7a38e9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c0ff20d3-a040-4961-adef-ec4bf959204b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e6c1df66-8c52-4929-a3d0-9509802e6107"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3451f4cb-eca6-4ca1-9093-1f201303c7ab"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0116897f-5f35-4102-b3e5-d6f00752245f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""048ffe48-c526-4fc6-98dc-22a8b957ee20"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d9428e4-a7fb-4c92-b3f2-b7bd81716b32"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19a8ebcf-c6ff-4065-8417-c6ef40c2e4d5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef45d301-a6c0-486a-a857-e908eecb56ca"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c0fa6d9-1b0d-4702-8f81-636b785b798e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8299d016-4083-48f7-8378-a936ae7f748a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""199f4302-9627-41be-b074-caf28779e6c5"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4ba247f-2073-4be7-8311-7373ebd52486"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ESC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b604179e-4293-44e9-9038-ebebc53d606a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""SanCheck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9be02315-88ab-49a3-b063-1dcaa66567eb"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SanCheck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7691f391-972d-4cee-8285-697022f37f38"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be1f9478-7b94-4ca5-b8c9-84f360b7a610"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4aac1e73-17c9-432a-803d-db783425b488"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""f8e89f73-bcc7-41b0-b631-299d802fb075"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""55fdf680-34ce-432b-a31a-270fd54bfea3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Arrow"",
                    ""type"": ""Value"",
                    ""id"": ""fe634999-f7ef-46cd-8f67-1e98efb9d89b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interactive"",
                    ""type"": ""Button"",
                    ""id"": ""d31b6434-1f4a-4c78-864b-ee777acd559b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""1d59311f-5e0c-4ea8-a442-5c7e9866b0ea"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""b24e0796-0824-42d9-a9eb-812ca2a87daf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e4c61226-034d-49ae-8fa7-a663dad2c470"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3936365c-4d6d-4991-9844-2b98ee439426"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrowkey"",
                    ""id"": ""27f52c5e-15ca-479b-b35c-fd189b745bd9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arrow"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8e59d835-545c-4d74-befc-eb8b0fc65e48"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c7e89b47-1c11-44bd-b7e1-6a9c871a2882"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""20333719-15b8-4eff-91c9-2236db2500fe"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""693f1454-c871-4e0a-93de-9074ddbfa141"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""38a18d5a-2042-45f7-8ae0-9e4a7349e315"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arrow"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4295824d-0525-4090-8ab0-ddb4f5b6ad24"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""82632026-7e02-4c3c-989b-3c12e6b31588"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6d8ded3d-8836-419a-8bb6-404a7ab1f15a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0d1faf7b-44ab-4265-a987-b0289e22d80c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""afc9065e-8a7b-484c-a21f-68dd6062dbbf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arrow"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f97b4a96-ad76-4deb-9df0-e743043bb650"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bbe41c54-05a5-4765-a1a3-55c3e018f793"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a888ed27-97ab-41ff-a685-ae26ed5328f4"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ca90c4d3-7c9f-40b2-8381-d765d10405fa"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""123908d9-d9bf-40ed-986f-99096d5996ae"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Interactive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdda5fd9-66cc-4585-a09d-591457a326dd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interactive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5849e43a-ed76-418a-990c-b741c8bbadf0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0097f339-4318-4205-8ef4-5b1cc3274583"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afda502a-e422-455d-a14c-26ea4095616e"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73bacddd-250b-4743-8caf-60dead2d07bc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord && Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keybord && Mouse"",
            ""bindingGroup"": ""Keybord && Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CombatLevel
        m_CombatLevel = asset.FindActionMap("CombatLevel", throwIfNotFound: true);
        m_CombatLevel_Move = m_CombatLevel.FindAction("Move", throwIfNotFound: true);
        m_CombatLevel_Roll = m_CombatLevel.FindAction("Roll", throwIfNotFound: true);
        m_CombatLevel_Attack = m_CombatLevel.FindAction("Attack", throwIfNotFound: true);
        m_CombatLevel_Skill = m_CombatLevel.FindAction("Skill", throwIfNotFound: true);
        m_CombatLevel_Heal = m_CombatLevel.FindAction("Heal", throwIfNotFound: true);
        m_CombatLevel_ESC = m_CombatLevel.FindAction("ESC", throwIfNotFound: true);
        m_CombatLevel_SanCheck = m_CombatLevel.FindAction("SanCheck", throwIfNotFound: true);
        m_CombatLevel_Interaction = m_CombatLevel.FindAction("Interaction", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Back = m_Menu.FindAction("Back", throwIfNotFound: true);
        m_Menu_Arrow = m_Menu.FindAction("Arrow", throwIfNotFound: true);
        m_Menu_Interactive = m_Menu.FindAction("Interactive", throwIfNotFound: true);
        m_Menu_LeftStick = m_Menu.FindAction("LeftStick", throwIfNotFound: true);
        m_Menu_Submit = m_Menu.FindAction("Submit", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // CombatLevel
    private readonly InputActionMap m_CombatLevel;
    private ICombatLevelActions m_CombatLevelActionsCallbackInterface;
    private readonly InputAction m_CombatLevel_Move;
    private readonly InputAction m_CombatLevel_Roll;
    private readonly InputAction m_CombatLevel_Attack;
    private readonly InputAction m_CombatLevel_Skill;
    private readonly InputAction m_CombatLevel_Heal;
    private readonly InputAction m_CombatLevel_ESC;
    private readonly InputAction m_CombatLevel_SanCheck;
    private readonly InputAction m_CombatLevel_Interaction;
    public struct CombatLevelActions
    {
        private @Controls m_Wrapper;
        public CombatLevelActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CombatLevel_Move;
        public InputAction @Roll => m_Wrapper.m_CombatLevel_Roll;
        public InputAction @Attack => m_Wrapper.m_CombatLevel_Attack;
        public InputAction @Skill => m_Wrapper.m_CombatLevel_Skill;
        public InputAction @Heal => m_Wrapper.m_CombatLevel_Heal;
        public InputAction @ESC => m_Wrapper.m_CombatLevel_ESC;
        public InputAction @SanCheck => m_Wrapper.m_CombatLevel_SanCheck;
        public InputAction @Interaction => m_Wrapper.m_CombatLevel_Interaction;
        public InputActionMap Get() { return m_Wrapper.m_CombatLevel; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatLevelActions set) { return set.Get(); }
        public void SetCallbacks(ICombatLevelActions instance)
        {
            if (m_Wrapper.m_CombatLevelActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnMove;
                @Roll.started -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnRoll;
                @Attack.started -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnAttack;
                @Skill.started -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnSkill;
                @Skill.performed -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnSkill;
                @Skill.canceled -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnSkill;
                @Heal.started -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnHeal;
                @Heal.performed -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnHeal;
                @Heal.canceled -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnHeal;
                @ESC.started -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnESC;
                @ESC.performed -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnESC;
                @ESC.canceled -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnESC;
                @SanCheck.started -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnSanCheck;
                @SanCheck.performed -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnSanCheck;
                @SanCheck.canceled -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnSanCheck;
                @Interaction.started -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_CombatLevelActionsCallbackInterface.OnInteraction;
            }
            m_Wrapper.m_CombatLevelActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Skill.started += instance.OnSkill;
                @Skill.performed += instance.OnSkill;
                @Skill.canceled += instance.OnSkill;
                @Heal.started += instance.OnHeal;
                @Heal.performed += instance.OnHeal;
                @Heal.canceled += instance.OnHeal;
                @ESC.started += instance.OnESC;
                @ESC.performed += instance.OnESC;
                @ESC.canceled += instance.OnESC;
                @SanCheck.started += instance.OnSanCheck;
                @SanCheck.performed += instance.OnSanCheck;
                @SanCheck.canceled += instance.OnSanCheck;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
            }
        }
    }
    public CombatLevelActions @CombatLevel => new CombatLevelActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Back;
    private readonly InputAction m_Menu_Arrow;
    private readonly InputAction m_Menu_Interactive;
    private readonly InputAction m_Menu_LeftStick;
    private readonly InputAction m_Menu_Submit;
    public struct MenuActions
    {
        private @Controls m_Wrapper;
        public MenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_Menu_Back;
        public InputAction @Arrow => m_Wrapper.m_Menu_Arrow;
        public InputAction @Interactive => m_Wrapper.m_Menu_Interactive;
        public InputAction @LeftStick => m_Wrapper.m_Menu_LeftStick;
        public InputAction @Submit => m_Wrapper.m_Menu_Submit;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                @Arrow.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnArrow;
                @Arrow.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnArrow;
                @Arrow.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnArrow;
                @Interactive.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnInteractive;
                @Interactive.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnInteractive;
                @Interactive.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnInteractive;
                @LeftStick.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeftStick;
                @Submit.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSubmit;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Arrow.started += instance.OnArrow;
                @Arrow.performed += instance.OnArrow;
                @Arrow.canceled += instance.OnArrow;
                @Interactive.started += instance.OnInteractive;
                @Interactive.performed += instance.OnInteractive;
                @Interactive.canceled += instance.OnInteractive;
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeybordMouseSchemeIndex = -1;
    public InputControlScheme KeybordMouseScheme
    {
        get
        {
            if (m_KeybordMouseSchemeIndex == -1) m_KeybordMouseSchemeIndex = asset.FindControlSchemeIndex("Keybord && Mouse");
            return asset.controlSchemes[m_KeybordMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ICombatLevelActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSkill(InputAction.CallbackContext context);
        void OnHeal(InputAction.CallbackContext context);
        void OnESC(InputAction.CallbackContext context);
        void OnSanCheck(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnArrow(InputAction.CallbackContext context);
        void OnInteractive(InputAction.CallbackContext context);
        void OnLeftStick(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
    }
}
