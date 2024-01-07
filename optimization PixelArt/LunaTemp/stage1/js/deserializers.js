var Deserializers = {}
Deserializers["UnityEngine.JointSpring"] = function (request, data, root) {
  var i434 = root || request.c( 'UnityEngine.JointSpring' )
  var i435 = data
  i434.spring = i435[0]
  i434.damper = i435[1]
  i434.targetPosition = i435[2]
  return i434
}

Deserializers["UnityEngine.JointMotor"] = function (request, data, root) {
  var i436 = root || request.c( 'UnityEngine.JointMotor' )
  var i437 = data
  i436.m_TargetVelocity = i437[0]
  i436.m_Force = i437[1]
  i436.m_FreeSpin = i437[2]
  return i436
}

Deserializers["UnityEngine.JointLimits"] = function (request, data, root) {
  var i438 = root || request.c( 'UnityEngine.JointLimits' )
  var i439 = data
  i438.m_Min = i439[0]
  i438.m_Max = i439[1]
  i438.m_Bounciness = i439[2]
  i438.m_BounceMinVelocity = i439[3]
  i438.m_ContactDistance = i439[4]
  i438.minBounce = i439[5]
  i438.maxBounce = i439[6]
  return i438
}

Deserializers["UnityEngine.JointDrive"] = function (request, data, root) {
  var i440 = root || request.c( 'UnityEngine.JointDrive' )
  var i441 = data
  i440.m_PositionSpring = i441[0]
  i440.m_PositionDamper = i441[1]
  i440.m_MaximumForce = i441[2]
  return i440
}

Deserializers["UnityEngine.SoftJointLimitSpring"] = function (request, data, root) {
  var i442 = root || request.c( 'UnityEngine.SoftJointLimitSpring' )
  var i443 = data
  i442.m_Spring = i443[0]
  i442.m_Damper = i443[1]
  return i442
}

Deserializers["UnityEngine.SoftJointLimit"] = function (request, data, root) {
  var i444 = root || request.c( 'UnityEngine.SoftJointLimit' )
  var i445 = data
  i444.m_Limit = i445[0]
  i444.m_Bounciness = i445[1]
  i444.m_ContactDistance = i445[2]
  return i444
}

Deserializers["UnityEngine.WheelFrictionCurve"] = function (request, data, root) {
  var i446 = root || request.c( 'UnityEngine.WheelFrictionCurve' )
  var i447 = data
  i446.m_ExtremumSlip = i447[0]
  i446.m_ExtremumValue = i447[1]
  i446.m_AsymptoteSlip = i447[2]
  i446.m_AsymptoteValue = i447[3]
  i446.m_Stiffness = i447[4]
  return i446
}

Deserializers["UnityEngine.JointAngleLimits2D"] = function (request, data, root) {
  var i448 = root || request.c( 'UnityEngine.JointAngleLimits2D' )
  var i449 = data
  i448.m_LowerAngle = i449[0]
  i448.m_UpperAngle = i449[1]
  return i448
}

Deserializers["UnityEngine.JointMotor2D"] = function (request, data, root) {
  var i450 = root || request.c( 'UnityEngine.JointMotor2D' )
  var i451 = data
  i450.m_MotorSpeed = i451[0]
  i450.m_MaximumMotorTorque = i451[1]
  return i450
}

Deserializers["UnityEngine.JointSuspension2D"] = function (request, data, root) {
  var i452 = root || request.c( 'UnityEngine.JointSuspension2D' )
  var i453 = data
  i452.m_DampingRatio = i453[0]
  i452.m_Frequency = i453[1]
  i452.m_Angle = i453[2]
  return i452
}

Deserializers["UnityEngine.JointTranslationLimits2D"] = function (request, data, root) {
  var i454 = root || request.c( 'UnityEngine.JointTranslationLimits2D' )
  var i455 = data
  i454.m_LowerTranslation = i455[0]
  i454.m_UpperTranslation = i455[1]
  return i454
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material"] = function (request, data, root) {
  var i456 = root || new pc.UnityMaterial()
  var i457 = data
  i456.name = i457[0]
  request.r(i457[1], i457[2], 0, i456, 'shader')
  i456.renderQueue = i457[3]
  i456.enableInstancing = !!i457[4]
  var i459 = i457[5]
  var i458 = []
  for(var i = 0; i < i459.length; i += 1) {
    i458.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter', i459[i + 0]) );
  }
  i456.floatParameters = i458
  var i461 = i457[6]
  var i460 = []
  for(var i = 0; i < i461.length; i += 1) {
    i460.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter', i461[i + 0]) );
  }
  i456.colorParameters = i460
  var i463 = i457[7]
  var i462 = []
  for(var i = 0; i < i463.length; i += 1) {
    i462.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter', i463[i + 0]) );
  }
  i456.vectorParameters = i462
  var i465 = i457[8]
  var i464 = []
  for(var i = 0; i < i465.length; i += 1) {
    i464.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter', i465[i + 0]) );
  }
  i456.textureParameters = i464
  var i467 = i457[9]
  var i466 = []
  for(var i = 0; i < i467.length; i += 1) {
    i466.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag', i467[i + 0]) );
  }
  i456.materialFlags = i466
  return i456
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter"] = function (request, data, root) {
  var i470 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter' )
  var i471 = data
  i470.name = i471[0]
  i470.value = i471[1]
  return i470
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter"] = function (request, data, root) {
  var i474 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter' )
  var i475 = data
  i474.name = i475[0]
  i474.value = new pc.Color(i475[1], i475[2], i475[3], i475[4])
  return i474
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter"] = function (request, data, root) {
  var i478 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter' )
  var i479 = data
  i478.name = i479[0]
  i478.value = new pc.Vec4( i479[1], i479[2], i479[3], i479[4] )
  return i478
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter"] = function (request, data, root) {
  var i482 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter' )
  var i483 = data
  i482.name = i483[0]
  request.r(i483[1], i483[2], 0, i482, 'value')
  return i482
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag"] = function (request, data, root) {
  var i486 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag' )
  var i487 = data
  i486.name = i487[0]
  i486.enabled = !!i487[1]
  return i486
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Texture2D"] = function (request, data, root) {
  var i488 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Texture2D' )
  var i489 = data
  i488.name = i489[0]
  i488.width = i489[1]
  i488.height = i489[2]
  i488.mipmapCount = i489[3]
  i488.anisoLevel = i489[4]
  i488.filterMode = i489[5]
  i488.hdr = !!i489[6]
  i488.format = i489[7]
  i488.wrapMode = i489[8]
  i488.alphaIsTransparency = !!i489[9]
  i488.alphaSource = i489[10]
  return i488
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.RectTransform"] = function (request, data, root) {
  var i490 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.RectTransform' )
  var i491 = data
  i490.pivot = new pc.Vec2( i491[0], i491[1] )
  i490.anchorMin = new pc.Vec2( i491[2], i491[3] )
  i490.anchorMax = new pc.Vec2( i491[4], i491[5] )
  i490.sizeDelta = new pc.Vec2( i491[6], i491[7] )
  i490.anchoredPosition3D = new pc.Vec3( i491[8], i491[9], i491[10] )
  i490.rotation = new pc.Quat(i491[11], i491[12], i491[13], i491[14])
  i490.scale = new pc.Vec3( i491[15], i491[16], i491[17] )
  return i490
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer"] = function (request, data, root) {
  var i492 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer' )
  var i493 = data
  i492.cullTransparentMesh = !!i493[0]
  return i492
}

Deserializers["UnityEngine.UI.Image"] = function (request, data, root) {
  var i494 = root || request.c( 'UnityEngine.UI.Image' )
  var i495 = data
  request.r(i495[0], i495[1], 0, i494, 'm_Sprite')
  i494.m_Type = i495[2]
  i494.m_PreserveAspect = !!i495[3]
  i494.m_FillCenter = !!i495[4]
  i494.m_FillMethod = i495[5]
  i494.m_FillAmount = i495[6]
  i494.m_FillClockwise = !!i495[7]
  i494.m_FillOrigin = i495[8]
  i494.m_UseSpriteMesh = !!i495[9]
  i494.m_PixelsPerUnitMultiplier = i495[10]
  request.r(i495[11], i495[12], 0, i494, 'm_Material')
  i494.m_Maskable = !!i495[13]
  i494.m_Color = new pc.Color(i495[14], i495[15], i495[16], i495[17])
  i494.m_RaycastTarget = !!i495[18]
  i494.m_RaycastPadding = new pc.Vec4( i495[19], i495[20], i495[21], i495[22] )
  return i494
}

Deserializers["UnityEngine.UI.GridLayoutGroup"] = function (request, data, root) {
  var i496 = root || request.c( 'UnityEngine.UI.GridLayoutGroup' )
  var i497 = data
  i496.m_StartCorner = i497[0]
  i496.m_StartAxis = i497[1]
  i496.m_CellSize = new pc.Vec2( i497[2], i497[3] )
  i496.m_Spacing = new pc.Vec2( i497[4], i497[5] )
  i496.m_Constraint = i497[6]
  i496.m_ConstraintCount = i497[7]
  i496.m_Padding = UnityEngine.RectOffset.FromPaddings(i497[8], i497[9], i497[10], i497[11])
  i496.m_ChildAlignment = i497[12]
  return i496
}

Deserializers["Luna.Unity.DTO.UnityEngine.Scene.GameObject"] = function (request, data, root) {
  var i498 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Scene.GameObject' )
  var i499 = data
  i498.name = i499[0]
  i498.tagId = i499[1]
  i498.enabled = !!i499[2]
  i498.isStatic = !!i499[3]
  i498.layer = i499[4]
  return i498
}

Deserializers["UnityEngine.UI.Button"] = function (request, data, root) {
  var i500 = root || request.c( 'UnityEngine.UI.Button' )
  var i501 = data
  i500.m_OnClick = request.d('UnityEngine.UI.Button+ButtonClickedEvent', i501[0], i500.m_OnClick)
  i500.m_Navigation = request.d('UnityEngine.UI.Navigation', i501[1], i500.m_Navigation)
  i500.m_Transition = i501[2]
  i500.m_Colors = request.d('UnityEngine.UI.ColorBlock', i501[3], i500.m_Colors)
  i500.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i501[4], i500.m_SpriteState)
  i500.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i501[5], i500.m_AnimationTriggers)
  i500.m_Interactable = !!i501[6]
  request.r(i501[7], i501[8], 0, i500, 'm_TargetGraphic')
  return i500
}

Deserializers["UnityEngine.UI.Button+ButtonClickedEvent"] = function (request, data, root) {
  var i502 = root || request.c( 'UnityEngine.UI.Button+ButtonClickedEvent' )
  var i503 = data
  i502.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i503[0], i502.m_PersistentCalls)
  return i502
}

Deserializers["UnityEngine.Events.PersistentCallGroup"] = function (request, data, root) {
  var i504 = root || request.c( 'UnityEngine.Events.PersistentCallGroup' )
  var i505 = data
  var i507 = i505[0]
  var i506 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Events.PersistentCall')))
  for(var i = 0; i < i507.length; i += 1) {
    i506.add(request.d('UnityEngine.Events.PersistentCall', i507[i + 0]));
  }
  i504.m_Calls = i506
  return i504
}

Deserializers["UnityEngine.Events.PersistentCall"] = function (request, data, root) {
  var i510 = root || request.c( 'UnityEngine.Events.PersistentCall' )
  var i511 = data
  request.r(i511[0], i511[1], 0, i510, 'm_Target')
  i510.m_TargetAssemblyTypeName = i511[2]
  i510.m_MethodName = i511[3]
  i510.m_Mode = i511[4]
  i510.m_Arguments = request.d('UnityEngine.Events.ArgumentCache', i511[5], i510.m_Arguments)
  i510.m_CallState = i511[6]
  return i510
}

Deserializers["UnityEngine.UI.Navigation"] = function (request, data, root) {
  var i512 = root || request.c( 'UnityEngine.UI.Navigation' )
  var i513 = data
  i512.m_Mode = i513[0]
  i512.m_WrapAround = !!i513[1]
  request.r(i513[2], i513[3], 0, i512, 'm_SelectOnUp')
  request.r(i513[4], i513[5], 0, i512, 'm_SelectOnDown')
  request.r(i513[6], i513[7], 0, i512, 'm_SelectOnLeft')
  request.r(i513[8], i513[9], 0, i512, 'm_SelectOnRight')
  return i512
}

Deserializers["UnityEngine.UI.ColorBlock"] = function (request, data, root) {
  var i514 = root || request.c( 'UnityEngine.UI.ColorBlock' )
  var i515 = data
  i514.m_NormalColor = new pc.Color(i515[0], i515[1], i515[2], i515[3])
  i514.m_HighlightedColor = new pc.Color(i515[4], i515[5], i515[6], i515[7])
  i514.m_PressedColor = new pc.Color(i515[8], i515[9], i515[10], i515[11])
  i514.m_SelectedColor = new pc.Color(i515[12], i515[13], i515[14], i515[15])
  i514.m_DisabledColor = new pc.Color(i515[16], i515[17], i515[18], i515[19])
  i514.m_ColorMultiplier = i515[20]
  i514.m_FadeDuration = i515[21]
  return i514
}

Deserializers["UnityEngine.UI.SpriteState"] = function (request, data, root) {
  var i516 = root || request.c( 'UnityEngine.UI.SpriteState' )
  var i517 = data
  request.r(i517[0], i517[1], 0, i516, 'm_HighlightedSprite')
  request.r(i517[2], i517[3], 0, i516, 'm_PressedSprite')
  request.r(i517[4], i517[5], 0, i516, 'm_SelectedSprite')
  request.r(i517[6], i517[7], 0, i516, 'm_DisabledSprite')
  return i516
}

Deserializers["UnityEngine.UI.AnimationTriggers"] = function (request, data, root) {
  var i518 = root || request.c( 'UnityEngine.UI.AnimationTriggers' )
  var i519 = data
  i518.m_NormalTrigger = i519[0]
  i518.m_HighlightedTrigger = i519[1]
  i518.m_PressedTrigger = i519[2]
  i518.m_SelectedTrigger = i519[3]
  i518.m_DisabledTrigger = i519[4]
  return i518
}

Deserializers["GetColorButton"] = function (request, data, root) {
  var i520 = root || request.c( 'GetColorButton' )
  var i521 = data
  i520.id = i521[0]
  i520.color = new pc.Color(i521[1], i521[2], i521[3], i521[4])
  request.r(i521[5], i521[6], 0, i520, 'textMeshPro')
  request.r(i521[7], i521[8], 0, i520, 'backGroundSlide')
  request.r(i521[9], i521[10], 0, i520, 'slide')
  request.r(i521[11], i521[12], 0, i520, 'tickCompelete')
  request.r(i521[13], i521[14], 0, i520, 'button')
  return i520
}

Deserializers["TMPro.TextMeshProUGUI"] = function (request, data, root) {
  var i522 = root || request.c( 'TMPro.TextMeshProUGUI' )
  var i523 = data
  i522.m_hasFontAssetChanged = !!i523[0]
  request.r(i523[1], i523[2], 0, i522, 'm_baseMaterial')
  i522.m_maskOffset = new pc.Vec4( i523[3], i523[4], i523[5], i523[6] )
  i522.m_text = i523[7]
  i522.m_isRightToLeft = !!i523[8]
  request.r(i523[9], i523[10], 0, i522, 'm_fontAsset')
  request.r(i523[11], i523[12], 0, i522, 'm_sharedMaterial')
  var i525 = i523[13]
  var i524 = []
  for(var i = 0; i < i525.length; i += 2) {
  request.r(i525[i + 0], i525[i + 1], 2, i524, '')
  }
  i522.m_fontSharedMaterials = i524
  request.r(i523[14], i523[15], 0, i522, 'm_fontMaterial')
  var i527 = i523[16]
  var i526 = []
  for(var i = 0; i < i527.length; i += 2) {
  request.r(i527[i + 0], i527[i + 1], 2, i526, '')
  }
  i522.m_fontMaterials = i526
  i522.m_fontColor32 = UnityEngine.Color32.ConstructColor(i523[17], i523[18], i523[19], i523[20])
  i522.m_fontColor = new pc.Color(i523[21], i523[22], i523[23], i523[24])
  i522.m_enableVertexGradient = !!i523[25]
  i522.m_colorMode = i523[26]
  i522.m_fontColorGradient = request.d('TMPro.VertexGradient', i523[27], i522.m_fontColorGradient)
  request.r(i523[28], i523[29], 0, i522, 'm_fontColorGradientPreset')
  request.r(i523[30], i523[31], 0, i522, 'm_spriteAsset')
  i522.m_tintAllSprites = !!i523[32]
  request.r(i523[33], i523[34], 0, i522, 'm_StyleSheet')
  i522.m_TextStyleHashCode = i523[35]
  i522.m_overrideHtmlColors = !!i523[36]
  i522.m_faceColor = UnityEngine.Color32.ConstructColor(i523[37], i523[38], i523[39], i523[40])
  i522.m_fontSize = i523[41]
  i522.m_fontSizeBase = i523[42]
  i522.m_fontWeight = i523[43]
  i522.m_enableAutoSizing = !!i523[44]
  i522.m_fontSizeMin = i523[45]
  i522.m_fontSizeMax = i523[46]
  i522.m_fontStyle = i523[47]
  i522.m_HorizontalAlignment = i523[48]
  i522.m_VerticalAlignment = i523[49]
  i522.m_textAlignment = i523[50]
  i522.m_characterSpacing = i523[51]
  i522.m_wordSpacing = i523[52]
  i522.m_lineSpacing = i523[53]
  i522.m_lineSpacingMax = i523[54]
  i522.m_paragraphSpacing = i523[55]
  i522.m_charWidthMaxAdj = i523[56]
  i522.m_enableWordWrapping = !!i523[57]
  i522.m_wordWrappingRatios = i523[58]
  i522.m_overflowMode = i523[59]
  request.r(i523[60], i523[61], 0, i522, 'm_linkedTextComponent')
  request.r(i523[62], i523[63], 0, i522, 'parentLinkedComponent')
  i522.m_enableKerning = !!i523[64]
  i522.m_enableExtraPadding = !!i523[65]
  i522.checkPaddingRequired = !!i523[66]
  i522.m_isRichText = !!i523[67]
  i522.m_parseCtrlCharacters = !!i523[68]
  i522.m_isOrthographic = !!i523[69]
  i522.m_isCullingEnabled = !!i523[70]
  i522.m_horizontalMapping = i523[71]
  i522.m_verticalMapping = i523[72]
  i522.m_uvLineOffset = i523[73]
  i522.m_geometrySortingOrder = i523[74]
  i522.m_IsTextObjectScaleStatic = !!i523[75]
  i522.m_VertexBufferAutoSizeReduction = !!i523[76]
  i522.m_useMaxVisibleDescender = !!i523[77]
  i522.m_pageToDisplay = i523[78]
  i522.m_margin = new pc.Vec4( i523[79], i523[80], i523[81], i523[82] )
  i522.m_isUsingLegacyAnimationComponent = !!i523[83]
  i522.m_isVolumetricText = !!i523[84]
  request.r(i523[85], i523[86], 0, i522, 'm_Material')
  i522.m_Maskable = !!i523[87]
  i522.m_Color = new pc.Color(i523[88], i523[89], i523[90], i523[91])
  i522.m_RaycastTarget = !!i523[92]
  i522.m_RaycastPadding = new pc.Vec4( i523[93], i523[94], i523[95], i523[96] )
  return i522
}

Deserializers["TMPro.VertexGradient"] = function (request, data, root) {
  var i530 = root || request.c( 'TMPro.VertexGradient' )
  var i531 = data
  i530.topLeft = new pc.Color(i531[0], i531[1], i531[2], i531[3])
  i530.topRight = new pc.Color(i531[4], i531[5], i531[6], i531[7])
  i530.bottomLeft = new pc.Color(i531[8], i531[9], i531[10], i531[11])
  i530.bottomRight = new pc.Color(i531[12], i531[13], i531[14], i531[15])
  return i530
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Canvas"] = function (request, data, root) {
  var i532 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Canvas' )
  var i533 = data
  i532.enabled = !!i533[0]
  i532.planeDistance = i533[1]
  i532.referencePixelsPerUnit = i533[2]
  i532.isFallbackOverlay = !!i533[3]
  i532.renderMode = i533[4]
  i532.renderOrder = i533[5]
  i532.sortingLayerName = i533[6]
  i532.sortingOrder = i533[7]
  i532.scaleFactor = i533[8]
  request.r(i533[9], i533[10], 0, i532, 'worldCamera')
  i532.overrideSorting = !!i533[11]
  i532.pixelPerfect = !!i533[12]
  i532.targetDisplay = i533[13]
  i532.overridePixelPerfect = !!i533[14]
  return i532
}

Deserializers["UnityEngine.UI.CanvasScaler"] = function (request, data, root) {
  var i534 = root || request.c( 'UnityEngine.UI.CanvasScaler' )
  var i535 = data
  i534.m_UiScaleMode = i535[0]
  i534.m_ReferencePixelsPerUnit = i535[1]
  i534.m_ScaleFactor = i535[2]
  i534.m_ReferenceResolution = new pc.Vec2( i535[3], i535[4] )
  i534.m_ScreenMatchMode = i535[5]
  i534.m_MatchWidthOrHeight = i535[6]
  i534.m_PhysicalUnit = i535[7]
  i534.m_FallbackScreenDPI = i535[8]
  i534.m_DefaultSpriteDPI = i535[9]
  i534.m_DynamicPixelsPerUnit = i535[10]
  i534.m_PresetInfoIsWorld = !!i535[11]
  return i534
}

Deserializers["UnityEngine.UI.GraphicRaycaster"] = function (request, data, root) {
  var i536 = root || request.c( 'UnityEngine.UI.GraphicRaycaster' )
  var i537 = data
  i536.m_IgnoreReversedGraphics = !!i537[0]
  i536.m_BlockingObjects = i537[1]
  i536.m_BlockingMask = UnityEngine.LayerMask.FromIntegerValue( i537[2] )
  return i536
}

Deserializers["StatsRecord"] = function (request, data, root) {
  var i538 = root || request.c( 'StatsRecord' )
  var i539 = data
  request.r(i539[0], i539[1], 0, i538, 'statsText')
  request.r(i539[2], i539[3], 0, i538, 'main')
  return i538
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Cubemap"] = function (request, data, root) {
  var i540 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Cubemap' )
  var i541 = data
  i540.name = i541[0]
  i540.atlasId = i541[1]
  i540.mipmapCount = i541[2]
  i540.hdr = !!i541[3]
  i540.size = i541[4]
  i540.anisoLevel = i541[5]
  i540.filterMode = i541[6]
  i540.wrapMode = i541[7]
  var i543 = i541[8]
  var i542 = []
  for(var i = 0; i < i543.length; i += 4) {
    i542.push( UnityEngine.Rect.MinMaxRect(i543[i + 0], i543[i + 1], i543[i + 2], i543[i + 3]) );
  }
  i540.rects = i542
  return i540
}

Deserializers["Luna.Unity.DTO.UnityEngine.Scene.Scene"] = function (request, data, root) {
  var i546 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Scene.Scene' )
  var i547 = data
  i546.name = i547[0]
  i546.index = i547[1]
  i546.startup = !!i547[2]
  return i546
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Transform"] = function (request, data, root) {
  var i548 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Transform' )
  var i549 = data
  i548.position = new pc.Vec3( i549[0], i549[1], i549[2] )
  i548.scale = new pc.Vec3( i549[3], i549[4], i549[5] )
  i548.rotation = new pc.Quat(i549[6], i549[7], i549[8], i549[9])
  return i548
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Camera"] = function (request, data, root) {
  var i550 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Camera' )
  var i551 = data
  i550.enabled = !!i551[0]
  i550.aspect = i551[1]
  i550.orthographic = !!i551[2]
  i550.orthographicSize = i551[3]
  i550.backgroundColor = new pc.Color(i551[4], i551[5], i551[6], i551[7])
  i550.nearClipPlane = i551[8]
  i550.farClipPlane = i551[9]
  i550.fieldOfView = i551[10]
  i550.depth = i551[11]
  i550.clearFlags = i551[12]
  i550.cullingMask = i551[13]
  i550.rect = i551[14]
  request.r(i551[15], i551[16], 0, i550, 'targetTexture')
  i550.usePhysicalProperties = !!i551[17]
  i550.focalLength = i551[18]
  i550.sensorSize = new pc.Vec2( i551[19], i551[20] )
  i550.lensShift = new pc.Vec2( i551[21], i551[22] )
  i550.gateFit = i551[23]
  return i550
}

Deserializers["Cinemachine.CinemachineBrain"] = function (request, data, root) {
  var i552 = root || request.c( 'Cinemachine.CinemachineBrain' )
  var i553 = data
  i552.m_ShowDebugText = !!i553[0]
  i552.m_ShowCameraFrustum = !!i553[1]
  i552.m_IgnoreTimeScale = !!i553[2]
  request.r(i553[3], i553[4], 0, i552, 'm_WorldUpOverride')
  i552.m_UpdateMethod = i553[5]
  i552.m_BlendUpdateMethod = i553[6]
  i552.m_DefaultBlend = request.d('Cinemachine.CinemachineBlendDefinition', i553[7], i552.m_DefaultBlend)
  request.r(i553[8], i553[9], 0, i552, 'm_CustomBlends')
  i552.m_CameraCutEvent = request.d('Cinemachine.CinemachineBrain+BrainEvent', i553[10], i552.m_CameraCutEvent)
  i552.m_CameraActivatedEvent = request.d('Cinemachine.CinemachineBrain+VcamActivatedEvent', i553[11], i552.m_CameraActivatedEvent)
  return i552
}

Deserializers["Cinemachine.CinemachineBlendDefinition"] = function (request, data, root) {
  var i554 = root || request.c( 'Cinemachine.CinemachineBlendDefinition' )
  var i555 = data
  i554.m_Style = i555[0]
  i554.m_Time = i555[1]
  i554.m_CustomCurve = new pc.AnimationCurve( { keys_flow: i555[2] } )
  return i554
}

Deserializers["Cinemachine.CinemachineBrain+BrainEvent"] = function (request, data, root) {
  var i556 = root || request.c( 'Cinemachine.CinemachineBrain+BrainEvent' )
  var i557 = data
  i556.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i557[0], i556.m_PersistentCalls)
  return i556
}

Deserializers["Cinemachine.CinemachineBrain+VcamActivatedEvent"] = function (request, data, root) {
  var i558 = root || request.c( 'Cinemachine.CinemachineBrain+VcamActivatedEvent' )
  var i559 = data
  i558.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i559[0], i558.m_PersistentCalls)
  return i558
}

Deserializers["CammeraMove"] = function (request, data, root) {
  var i560 = root || request.c( 'CammeraMove' )
  var i561 = data
  request.r(i561[0], i561[1], 0, i560, 'slider')
  i560.canMoveCam = !!i561[2]
  request.r(i561[3], i561[4], 0, i560, 'cam')
  i560.ceterGame = new pc.Vec3( i561[5], i561[6], i561[7] )
  request.r(i561[8], i561[9], 0, i560, 'camlookat')
  request.r(i561[10], i561[11], 0, i560, 'virturalcam')
  return i560
}

Deserializers["GameManager"] = function (request, data, root) {
  var i562 = root || request.c( 'GameManager' )
  var i563 = data
  i562.TestSize = i563[0]
  i562.idNow = i563[1]
  i562.colorNow = new pc.Color(i563[2], i563[3], i563[4], i563[5])
  request.r(i563[6], i563[7], 0, i562, 'sprite')
  request.r(i563[8], i563[9], 0, i562, 'textureTrue')
  request.r(i563[10], i563[11], 0, i562, 'tileMapLine')
  request.r(i563[12], i563[13], 0, i562, 'tileMapRenColor')
  request.r(i563[14], i563[15], 0, i562, 'tileMapHighLight')
  request.r(i563[16], i563[17], 0, i562, 'tilemapNumber')
  request.r(i563[18], i563[19], 0, i562, 'tileMapWhiteRenColor')
  request.r(i563[20], i563[21], 0, i562, '_smallTile')
  request.r(i563[22], i563[23], 0, i562, '_lineBigTile')
  var i565 = i563[24]
  var i564 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Tilemaps.Tile')))
  for(var i = 0; i < i565.length; i += 2) {
  request.r(i565[i + 0], i565[i + 1], 1, i564, '')
  }
  i562.number = i564
  i562.totalPage = i563[25]
  var i567 = i563[26]
  var i566 = new (System.Collections.Generic.List$1(Bridge.ns('GetColorButton')))
  for(var i = 0; i < i567.length; i += 2) {
  request.r(i567[i + 0], i567[i + 1], 1, i566, '')
  }
  i562.allGetColorButton = i566
  request.r(i563[27], i563[28], 0, i562, 'pageColorSwipe')
  request.r(i563[29], i563[30], 0, i562, 'canvas')
  request.r(i563[31], i563[32], 0, i562, 'getColorButtonNow')
  request.r(i563[33], i563[34], 0, i562, 'cam')
  request.r(i563[35], i563[36], 0, i562, 'pageParent')
  request.r(i563[37], i563[38], 0, i562, 'pageprefabs')
  request.r(i563[39], i563[40], 0, i562, 'getColorButtonPrefabs')
  request.r(i563[41], i563[42], 0, i562, 'slider')
  return i562
}

Deserializers["FillPixel"] = function (request, data, root) {
  var i572 = root || request.c( 'FillPixel' )
  var i573 = data
  request.r(i573[0], i573[1], 0, i572, 'cam')
  request.r(i573[2], i573[3], 0, i572, 'tileMapLine')
  request.r(i573[4], i573[5], 0, i572, 'tileMapRenColor')
  request.r(i573[6], i573[7], 0, i572, 'tileMapHighLight')
  request.r(i573[8], i573[9], 0, i572, 'tilemapNumber')
  request.r(i573[10], i573[11], 0, i572, 'tilemapWhiteColorNumber')
  i572.status = i573[12]
  return i572
}

Deserializers["PageColorSwipe"] = function (request, data, root) {
  var i574 = root || request.c( 'PageColorSwipe' )
  var i575 = data
  i574.percentThreshold = i575[0]
  i574.speed01 = i575[1]
  i574.totalPages = i575[2]
  i574.currentPage = i575[3]
  request.r(i575[4], i575[5], 0, i574, '_boobHighLight')
  request.r(i575[6], i575[7], 0, i574, '_stickHighLight')
  return i574
}

Deserializers["ChosseStatusBtn"] = function (request, data, root) {
  var i576 = root || request.c( 'ChosseStatusBtn' )
  var i577 = data
  i576.chosseStatus = i577[0]
  request.r(i577[1], i577[2], 0, i576, '_highlight')
  request.r(i577[3], i577[4], 0, i576, 'button')
  return i576
}

Deserializers["UnityEngine.Events.ArgumentCache"] = function (request, data, root) {
  var i578 = root || request.c( 'UnityEngine.Events.ArgumentCache' )
  var i579 = data
  request.r(i579[0], i579[1], 0, i578, 'm_ObjectArgument')
  i578.m_ObjectArgumentAssemblyTypeName = i579[2]
  i578.m_IntArgument = i579[3]
  i578.m_FloatArgument = i579[4]
  i578.m_StringArgument = i579[5]
  i578.m_BoolArgument = !!i579[6]
  return i578
}

Deserializers["UnityEngine.UI.Slider"] = function (request, data, root) {
  var i580 = root || request.c( 'UnityEngine.UI.Slider' )
  var i581 = data
  request.r(i581[0], i581[1], 0, i580, 'm_FillRect')
  request.r(i581[2], i581[3], 0, i580, 'm_HandleRect')
  i580.m_Direction = i581[4]
  i580.m_MinValue = i581[5]
  i580.m_MaxValue = i581[6]
  i580.m_WholeNumbers = !!i581[7]
  i580.m_Value = i581[8]
  i580.m_OnValueChanged = request.d('UnityEngine.UI.Slider+SliderEvent', i581[9], i580.m_OnValueChanged)
  i580.m_Navigation = request.d('UnityEngine.UI.Navigation', i581[10], i580.m_Navigation)
  i580.m_Transition = i581[11]
  i580.m_Colors = request.d('UnityEngine.UI.ColorBlock', i581[12], i580.m_Colors)
  i580.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i581[13], i580.m_SpriteState)
  i580.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i581[14], i580.m_AnimationTriggers)
  i580.m_Interactable = !!i581[15]
  request.r(i581[16], i581[17], 0, i580, 'm_TargetGraphic')
  return i580
}

Deserializers["UnityEngine.UI.Slider+SliderEvent"] = function (request, data, root) {
  var i582 = root || request.c( 'UnityEngine.UI.Slider+SliderEvent' )
  var i583 = data
  i582.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i583[0], i582.m_PersistentCalls)
  return i582
}

Deserializers["UnityEngine.EventSystems.EventSystem"] = function (request, data, root) {
  var i584 = root || request.c( 'UnityEngine.EventSystems.EventSystem' )
  var i585 = data
  request.r(i585[0], i585[1], 0, i584, 'm_FirstSelected')
  i584.m_sendNavigationEvents = !!i585[2]
  i584.m_DragThreshold = i585[3]
  return i584
}

Deserializers["UnityEngine.EventSystems.StandaloneInputModule"] = function (request, data, root) {
  var i586 = root || request.c( 'UnityEngine.EventSystems.StandaloneInputModule' )
  var i587 = data
  i586.m_HorizontalAxis = i587[0]
  i586.m_VerticalAxis = i587[1]
  i586.m_SubmitButton = i587[2]
  i586.m_CancelButton = i587[3]
  i586.m_InputActionsPerSecond = i587[4]
  i586.m_RepeatDelay = i587[5]
  i586.m_ForceModuleActive = !!i587[6]
  i586.m_SendPointerHoverToParent = !!i587[7]
  return i586
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer"] = function (request, data, root) {
  var i588 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer' )
  var i589 = data
  i588.enabled = !!i589[0]
  request.r(i589[1], i589[2], 0, i588, 'sharedMaterial')
  var i591 = i589[3]
  var i590 = []
  for(var i = 0; i < i591.length; i += 2) {
  request.r(i591[i + 0], i591[i + 1], 2, i590, '')
  }
  i588.sharedMaterials = i590
  i588.receiveShadows = !!i589[4]
  i588.shadowCastingMode = i589[5]
  i588.sortingLayerID = i589[6]
  i588.sortingOrder = i589[7]
  i588.lightmapIndex = i589[8]
  i588.lightmapSceneIndex = i589[9]
  i588.lightmapScaleOffset = new pc.Vec4( i589[10], i589[11], i589[12], i589[13] )
  i588.lightProbeUsage = i589[14]
  i588.reflectionProbeUsage = i589[15]
  i588.color = new pc.Color(i589[16], i589[17], i589[18], i589[19])
  request.r(i589[20], i589[21], 0, i588, 'sprite')
  i588.flipX = !!i589[22]
  i588.flipY = !!i589[23]
  i588.drawMode = i589[24]
  i588.size = new pc.Vec2( i589[25], i589[26] )
  i588.tileMode = i589[27]
  i588.adaptiveModeThreshold = i589[28]
  i588.maskInteraction = i589[29]
  i588.spriteSortPoint = i589[30]
  return i588
}

Deserializers["Cinemachine.CinemachineVirtualCamera"] = function (request, data, root) {
  var i592 = root || request.c( 'Cinemachine.CinemachineVirtualCamera' )
  var i593 = data
  request.r(i593[0], i593[1], 0, i592, 'm_LookAt')
  request.r(i593[2], i593[3], 0, i592, 'm_Follow')
  i592.m_Lens = request.d('Cinemachine.LensSettings', i593[4], i592.m_Lens)
  i592.m_Transitions = request.d('Cinemachine.CinemachineVirtualCameraBase+TransitionParams', i593[5], i592.m_Transitions)
  var i595 = i593[6]
  var i594 = []
  for(var i = 0; i < i595.length; i += 1) {
    i594.push( i595[i + 0] );
  }
  i592.m_ExcludedPropertiesInInspector = i594
  var i597 = i593[7]
  var i596 = []
  for(var i = 0; i < i597.length; i += 1) {
    i596.push( i597[i + 0] );
  }
  i592.m_LockStageInInspector = i596
  i592.m_Priority = i593[8]
  i592.m_StandbyUpdate = i593[9]
  i592.m_LegacyBlendHint = i593[10]
  request.r(i593[11], i593[12], 0, i592, 'm_ComponentOwner')
  i592.m_StreamingVersion = i593[13]
  return i592
}

Deserializers["Cinemachine.LensSettings"] = function (request, data, root) {
  var i598 = root || request.c( 'Cinemachine.LensSettings' )
  var i599 = data
  i598.FieldOfView = i599[0]
  i598.OrthographicSize = i599[1]
  i598.NearClipPlane = i599[2]
  i598.FarClipPlane = i599[3]
  i598.Dutch = i599[4]
  i598.ModeOverride = i599[5]
  i598.LensShift = new pc.Vec2( i599[6], i599[7] )
  i598.GateFit = i599[8]
  i598.m_SensorSize = new pc.Vec2( i599[9], i599[10] )
  return i598
}

Deserializers["Cinemachine.CinemachineVirtualCameraBase+TransitionParams"] = function (request, data, root) {
  var i600 = root || request.c( 'Cinemachine.CinemachineVirtualCameraBase+TransitionParams' )
  var i601 = data
  i600.m_BlendHint = i601[0]
  i600.m_InheritPosition = !!i601[1]
  i600.m_OnCameraLive = request.d('Cinemachine.CinemachineBrain+VcamActivatedEvent', i601[2], i600.m_OnCameraLive)
  return i600
}

Deserializers["Cinemachine.CinemachinePipeline"] = function (request, data, root) {
  var i606 = root || request.c( 'Cinemachine.CinemachinePipeline' )
  var i607 = data
  return i606
}

Deserializers["Cinemachine.CinemachineComposer"] = function (request, data, root) {
  var i608 = root || request.c( 'Cinemachine.CinemachineComposer' )
  var i609 = data
  i608.m_TrackedObjectOffset = new pc.Vec3( i609[0], i609[1], i609[2] )
  i608.m_LookaheadTime = i609[3]
  i608.m_LookaheadSmoothing = i609[4]
  i608.m_LookaheadIgnoreY = !!i609[5]
  i608.m_HorizontalDamping = i609[6]
  i608.m_VerticalDamping = i609[7]
  i608.m_ScreenX = i609[8]
  i608.m_ScreenY = i609[9]
  i608.m_DeadZoneWidth = i609[10]
  i608.m_DeadZoneHeight = i609[11]
  i608.m_SoftZoneWidth = i609[12]
  i608.m_SoftZoneHeight = i609[13]
  i608.m_BiasX = i609[14]
  i608.m_BiasY = i609[15]
  i608.m_CenterOnActivate = !!i609[16]
  return i608
}

Deserializers["Cinemachine.CinemachineFramingTransposer"] = function (request, data, root) {
  var i610 = root || request.c( 'Cinemachine.CinemachineFramingTransposer' )
  var i611 = data
  i610.m_TrackedObjectOffset = new pc.Vec3( i611[0], i611[1], i611[2] )
  i610.m_LookaheadTime = i611[3]
  i610.m_LookaheadSmoothing = i611[4]
  i610.m_LookaheadIgnoreY = !!i611[5]
  i610.m_XDamping = i611[6]
  i610.m_YDamping = i611[7]
  i610.m_ZDamping = i611[8]
  i610.m_TargetMovementOnly = !!i611[9]
  i610.m_ScreenX = i611[10]
  i610.m_ScreenY = i611[11]
  i610.m_CameraDistance = i611[12]
  i610.m_DeadZoneWidth = i611[13]
  i610.m_DeadZoneHeight = i611[14]
  i610.m_DeadZoneDepth = i611[15]
  i610.m_UnlimitedSoftZone = !!i611[16]
  i610.m_SoftZoneWidth = i611[17]
  i610.m_SoftZoneHeight = i611[18]
  i610.m_BiasX = i611[19]
  i610.m_BiasY = i611[20]
  i610.m_CenterOnActivate = !!i611[21]
  i610.m_GroupFramingMode = i611[22]
  i610.m_AdjustmentMode = i611[23]
  i610.m_GroupFramingSize = i611[24]
  i610.m_MaxDollyIn = i611[25]
  i610.m_MaxDollyOut = i611[26]
  i610.m_MinimumDistance = i611[27]
  i610.m_MaximumDistance = i611[28]
  i610.m_MinimumFOV = i611[29]
  i610.m_MaximumFOV = i611[30]
  i610.m_MinimumOrthoSize = i611[31]
  i610.m_MaximumOrthoSize = i611[32]
  return i610
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings"] = function (request, data, root) {
  var i612 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderSettings' )
  var i613 = data
  i612.ambientIntensity = i613[0]
  i612.reflectionIntensity = i613[1]
  i612.ambientMode = i613[2]
  i612.ambientLight = new pc.Color(i613[3], i613[4], i613[5], i613[6])
  i612.ambientSkyColor = new pc.Color(i613[7], i613[8], i613[9], i613[10])
  i612.ambientGroundColor = new pc.Color(i613[11], i613[12], i613[13], i613[14])
  i612.ambientEquatorColor = new pc.Color(i613[15], i613[16], i613[17], i613[18])
  i612.fogColor = new pc.Color(i613[19], i613[20], i613[21], i613[22])
  i612.fogEndDistance = i613[23]
  i612.fogStartDistance = i613[24]
  i612.fogDensity = i613[25]
  i612.fog = !!i613[26]
  request.r(i613[27], i613[28], 0, i612, 'skybox')
  i612.fogMode = i613[29]
  var i615 = i613[30]
  var i614 = []
  for(var i = 0; i < i615.length; i += 1) {
    i614.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap', i615[i + 0]) );
  }
  i612.lightmaps = i614
  i612.lightProbes = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes', i613[31], i612.lightProbes)
  i612.lightmapsMode = i613[32]
  i612.mixedBakeMode = i613[33]
  i612.environmentLightingMode = i613[34]
  i612.ambientProbe = new pc.SphericalHarmonicsL2(i613[35])
  i612.referenceAmbientProbe = new pc.SphericalHarmonicsL2(i613[36])
  i612.useReferenceAmbientProbe = !!i613[37]
  request.r(i613[38], i613[39], 0, i612, 'customReflection')
  request.r(i613[40], i613[41], 0, i612, 'defaultReflection')
  i612.defaultReflectionMode = i613[42]
  i612.defaultReflectionResolution = i613[43]
  i612.sunLightObjectId = i613[44]
  i612.pixelLightCount = i613[45]
  i612.defaultReflectionHDR = !!i613[46]
  i612.hasLightDataAsset = !!i613[47]
  i612.hasManualGenerate = !!i613[48]
  return i612
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap"] = function (request, data, root) {
  var i618 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap' )
  var i619 = data
  request.r(i619[0], i619[1], 0, i618, 'lightmapColor')
  request.r(i619[2], i619[3], 0, i618, 'lightmapDirection')
  return i618
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes"] = function (request, data, root) {
  var i620 = root || new UnityEngine.LightProbes()
  var i621 = data
  return i620
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader"] = function (request, data, root) {
  var i628 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader' )
  var i629 = data
  var i631 = i629[0]
  var i630 = new (System.Collections.Generic.List$1(Bridge.ns('System.String')))
  for(var i = 0; i < i631.length; i += 1) {
    i630.add(i631[i + 0]);
  }
  i628.invalidShaderVariants = i630
  i628.name = i629[1]
  i628.guid = i629[2]
  var i633 = i629[3]
  var i632 = []
  for(var i = 0; i < i633.length; i += 1) {
    i632.push( i633[i + 0] );
  }
  i628.shaderDefinedKeywords = i632
  var i635 = i629[4]
  var i634 = []
  for(var i = 0; i < i635.length; i += 1) {
    i634.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass', i635[i + 0]) );
  }
  i628.passes = i634
  var i637 = i629[5]
  var i636 = []
  for(var i = 0; i < i637.length; i += 1) {
    i636.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass', i637[i + 0]) );
  }
  i628.usePasses = i636
  var i639 = i629[6]
  var i638 = []
  for(var i = 0; i < i639.length; i += 1) {
    i638.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue', i639[i + 0]) );
  }
  i628.defaultParameterValues = i638
  request.r(i629[7], i629[8], 0, i628, 'unityFallbackShader')
  i628.readDepth = !!i629[9]
  i628.isCreatedByShaderGraph = !!i629[10]
  i628.usedBatchUniforms = i629[11]
  return i628
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass"] = function (request, data, root) {
  var i644 = root || new pc.UnityShaderPass()
  var i645 = data
  i644.id = i645[0]
  i644.subShaderIndex = i645[1]
  i644.name = i645[2]
  i644.passType = i645[3]
  i644.usePass = !!i645[4]
  i644.zTest = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i645[5], i644.zTest)
  i644.zWrite = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i645[6], i644.zWrite)
  i644.culling = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i645[7], i644.culling)
  i644.blending = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending', i645[8], i644.blending)
  i644.alphaBlending = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending', i645[9], i644.alphaBlending)
  i644.colorWriteMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i645[10], i644.colorWriteMask)
  i644.offsetUnits = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i645[11], i644.offsetUnits)
  i644.offsetFactor = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i645[12], i644.offsetFactor)
  i644.stencilRef = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i645[13], i644.stencilRef)
  i644.stencilReadMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i645[14], i644.stencilReadMask)
  i644.stencilWriteMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i645[15], i644.stencilWriteMask)
  i644.stencilOp = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i645[16], i644.stencilOp)
  i644.stencilOpFront = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i645[17], i644.stencilOpFront)
  i644.stencilOpBack = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i645[18], i644.stencilOpBack)
  var i647 = i645[19]
  var i646 = []
  for(var i = 0; i < i647.length; i += 1) {
    i646.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag', i647[i + 0]) );
  }
  i644.tags = i646
  var i649 = i645[20]
  var i648 = []
  for(var i = 0; i < i649.length; i += 1) {
    i648.push( i649[i + 0] );
  }
  i644.passDefinedKeywords = i648
  var i651 = i645[21]
  var i650 = []
  for(var i = 0; i < i651.length; i += 1) {
    i650.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup', i651[i + 0]) );
  }
  i644.passDefinedKeywordGroups = i650
  var i653 = i645[22]
  var i652 = []
  for(var i = 0; i < i653.length; i += 1) {
    i652.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant', i653[i + 0]) );
  }
  i644.variants = i652
  var i655 = i645[23]
  var i654 = []
  for(var i = 0; i < i655.length; i += 1) {
    i654.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant', i655[i + 0]) );
  }
  i644.excludedVariants = i654
  i644.hasDepthReader = !!i645[24]
  return i644
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value"] = function (request, data, root) {
  var i656 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value' )
  var i657 = data
  i656.val = i657[0]
  i656.name = i657[1]
  return i656
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending"] = function (request, data, root) {
  var i658 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending' )
  var i659 = data
  i658.src = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i659[0], i658.src)
  i658.dst = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i659[1], i658.dst)
  i658.op = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i659[2], i658.op)
  return i658
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp"] = function (request, data, root) {
  var i660 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp' )
  var i661 = data
  i660.pass = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i661[0], i660.pass)
  i660.fail = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i661[1], i660.fail)
  i660.zFail = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i661[2], i660.zFail)
  i660.comp = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i661[3], i660.comp)
  return i660
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag"] = function (request, data, root) {
  var i664 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag' )
  var i665 = data
  i664.name = i665[0]
  i664.value = i665[1]
  return i664
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup"] = function (request, data, root) {
  var i668 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup' )
  var i669 = data
  var i671 = i669[0]
  var i670 = []
  for(var i = 0; i < i671.length; i += 1) {
    i670.push( i671[i + 0] );
  }
  i668.keywords = i670
  i668.hasDiscard = !!i669[1]
  return i668
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant"] = function (request, data, root) {
  var i674 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant' )
  var i675 = data
  i674.passId = i675[0]
  i674.subShaderIndex = i675[1]
  var i677 = i675[2]
  var i676 = []
  for(var i = 0; i < i677.length; i += 1) {
    i676.push( i677[i + 0] );
  }
  i674.keywords = i676
  i674.vertexProgram = i675[3]
  i674.fragmentProgram = i675[4]
  i674.readDepth = !!i675[5]
  return i674
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass"] = function (request, data, root) {
  var i680 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass' )
  var i681 = data
  request.r(i681[0], i681[1], 0, i680, 'shader')
  i680.pass = i681[2]
  return i680
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue"] = function (request, data, root) {
  var i684 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue' )
  var i685 = data
  i684.name = i685[0]
  i684.type = i685[1]
  i684.value = new pc.Vec4( i685[2], i685[3], i685[4], i685[5] )
  i684.textureValue = i685[6]
  return i684
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Sprite"] = function (request, data, root) {
  var i686 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Sprite' )
  var i687 = data
  i686.name = i687[0]
  request.r(i687[1], i687[2], 0, i686, 'texture')
  i686.aabb = i687[3]
  i686.vertices = i687[4]
  i686.triangles = i687[5]
  i686.textureRect = UnityEngine.Rect.MinMaxRect(i687[6], i687[7], i687[8], i687[9])
  i686.packedRect = UnityEngine.Rect.MinMaxRect(i687[10], i687[11], i687[12], i687[13])
  i686.border = new pc.Vec4( i687[14], i687[15], i687[16], i687[17] )
  i686.transparency = i687[18]
  i686.bounds = i687[19]
  i686.pixelsPerUnit = i687[20]
  i686.textureWidth = i687[21]
  i686.textureHeight = i687[22]
  i686.nativeSize = new pc.Vec2( i687[23], i687[24] )
  i686.pivot = new pc.Vec2( i687[25], i687[26] )
  i686.textureRectOffset = new pc.Vec2( i687[27], i687[28] )
  return i686
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Font"] = function (request, data, root) {
  var i688 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Font' )
  var i689 = data
  i688.name = i689[0]
  i688.ascent = i689[1]
  i688.originalLineHeight = i689[2]
  i688.fontSize = i689[3]
  var i691 = i689[4]
  var i690 = []
  for(var i = 0; i < i691.length; i += 1) {
    i690.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo', i691[i + 0]) );
  }
  i688.characterInfo = i690
  request.r(i689[5], i689[6], 0, i688, 'texture')
  i688.originalFontSize = i689[7]
  return i688
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo"] = function (request, data, root) {
  var i694 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo' )
  var i695 = data
  i694.index = i695[0]
  i694.advance = i695[1]
  i694.bearing = i695[2]
  i694.glyphWidth = i695[3]
  i694.glyphHeight = i695[4]
  i694.minX = i695[5]
  i694.maxX = i695[6]
  i694.minY = i695[7]
  i694.maxY = i695[8]
  i694.uvBottomLeftX = i695[9]
  i694.uvBottomLeftY = i695[10]
  i694.uvBottomRightX = i695[11]
  i694.uvBottomRightY = i695[12]
  i694.uvTopLeftX = i695[13]
  i694.uvTopLeftY = i695[14]
  i694.uvTopRightX = i695[15]
  i694.uvTopRightY = i695[16]
  return i694
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.TextAsset"] = function (request, data, root) {
  var i696 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.TextAsset' )
  var i697 = data
  i696.name = i697[0]
  i696.bytes64 = i697[1]
  i696.data = i697[2]
  return i696
}

Deserializers["TMPro.TMP_FontAsset"] = function (request, data, root) {
  var i698 = root || request.c( 'TMPro.TMP_FontAsset' )
  var i699 = data
  i698.hashCode = i699[0]
  request.r(i699[1], i699[2], 0, i698, 'material')
  i698.materialHashCode = i699[3]
  request.r(i699[4], i699[5], 0, i698, 'atlas')
  i698.normalStyle = i699[6]
  i698.normalSpacingOffset = i699[7]
  i698.boldStyle = i699[8]
  i698.boldSpacing = i699[9]
  i698.italicStyle = i699[10]
  i698.tabSize = i699[11]
  i698.m_Version = i699[12]
  i698.m_SourceFontFileGUID = i699[13]
  request.r(i699[14], i699[15], 0, i698, 'm_SourceFontFile_EditorRef')
  request.r(i699[16], i699[17], 0, i698, 'm_SourceFontFile')
  i698.m_AtlasPopulationMode = i699[18]
  i698.m_FaceInfo = request.d('UnityEngine.TextCore.FaceInfo', i699[19], i698.m_FaceInfo)
  var i701 = i699[20]
  var i700 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.Glyph')))
  for(var i = 0; i < i701.length; i += 1) {
    i700.add(request.d('UnityEngine.TextCore.Glyph', i701[i + 0]));
  }
  i698.m_GlyphTable = i700
  var i703 = i699[21]
  var i702 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Character')))
  for(var i = 0; i < i703.length; i += 1) {
    i702.add(request.d('TMPro.TMP_Character', i703[i + 0]));
  }
  i698.m_CharacterTable = i702
  var i705 = i699[22]
  var i704 = []
  for(var i = 0; i < i705.length; i += 2) {
  request.r(i705[i + 0], i705[i + 1], 2, i704, '')
  }
  i698.m_AtlasTextures = i704
  i698.m_AtlasTextureIndex = i699[23]
  i698.m_IsMultiAtlasTexturesEnabled = !!i699[24]
  i698.m_ClearDynamicDataOnBuild = !!i699[25]
  var i707 = i699[26]
  var i706 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.GlyphRect')))
  for(var i = 0; i < i707.length; i += 1) {
    i706.add(request.d('UnityEngine.TextCore.GlyphRect', i707[i + 0]));
  }
  i698.m_UsedGlyphRects = i706
  var i709 = i699[27]
  var i708 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.GlyphRect')))
  for(var i = 0; i < i709.length; i += 1) {
    i708.add(request.d('UnityEngine.TextCore.GlyphRect', i709[i + 0]));
  }
  i698.m_FreeGlyphRects = i708
  i698.m_fontInfo = request.d('TMPro.FaceInfo_Legacy', i699[28], i698.m_fontInfo)
  i698.m_AtlasWidth = i699[29]
  i698.m_AtlasHeight = i699[30]
  i698.m_AtlasPadding = i699[31]
  i698.m_AtlasRenderMode = i699[32]
  var i711 = i699[33]
  var i710 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Glyph')))
  for(var i = 0; i < i711.length; i += 1) {
    i710.add(request.d('TMPro.TMP_Glyph', i711[i + 0]));
  }
  i698.m_glyphInfoList = i710
  i698.m_KerningTable = request.d('TMPro.KerningTable', i699[34], i698.m_KerningTable)
  i698.m_FontFeatureTable = request.d('TMPro.TMP_FontFeatureTable', i699[35], i698.m_FontFeatureTable)
  var i713 = i699[36]
  var i712 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i713.length; i += 2) {
  request.r(i713[i + 0], i713[i + 1], 1, i712, '')
  }
  i698.fallbackFontAssets = i712
  var i715 = i699[37]
  var i714 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i715.length; i += 2) {
  request.r(i715[i + 0], i715[i + 1], 1, i714, '')
  }
  i698.m_FallbackFontAssetTable = i714
  i698.m_CreationSettings = request.d('TMPro.FontAssetCreationSettings', i699[38], i698.m_CreationSettings)
  var i717 = i699[39]
  var i716 = []
  for(var i = 0; i < i717.length; i += 1) {
    i716.push( request.d('TMPro.TMP_FontWeightPair', i717[i + 0]) );
  }
  i698.m_FontWeightTable = i716
  var i719 = i699[40]
  var i718 = []
  for(var i = 0; i < i719.length; i += 1) {
    i718.push( request.d('TMPro.TMP_FontWeightPair', i719[i + 0]) );
  }
  i698.fontWeights = i718
  return i698
}

Deserializers["UnityEngine.TextCore.FaceInfo"] = function (request, data, root) {
  var i720 = root || request.c( 'UnityEngine.TextCore.FaceInfo' )
  var i721 = data
  i720.m_FaceIndex = i721[0]
  i720.m_FamilyName = i721[1]
  i720.m_StyleName = i721[2]
  i720.m_PointSize = i721[3]
  i720.m_Scale = i721[4]
  i720.m_LineHeight = i721[5]
  i720.m_AscentLine = i721[6]
  i720.m_CapLine = i721[7]
  i720.m_MeanLine = i721[8]
  i720.m_Baseline = i721[9]
  i720.m_DescentLine = i721[10]
  i720.m_SuperscriptOffset = i721[11]
  i720.m_SuperscriptSize = i721[12]
  i720.m_SubscriptOffset = i721[13]
  i720.m_SubscriptSize = i721[14]
  i720.m_UnderlineOffset = i721[15]
  i720.m_UnderlineThickness = i721[16]
  i720.m_StrikethroughOffset = i721[17]
  i720.m_StrikethroughThickness = i721[18]
  i720.m_TabWidth = i721[19]
  return i720
}

Deserializers["UnityEngine.TextCore.Glyph"] = function (request, data, root) {
  var i724 = root || request.c( 'UnityEngine.TextCore.Glyph' )
  var i725 = data
  i724.m_Index = i725[0]
  i724.m_Metrics = request.d('UnityEngine.TextCore.GlyphMetrics', i725[1], i724.m_Metrics)
  i724.m_GlyphRect = request.d('UnityEngine.TextCore.GlyphRect', i725[2], i724.m_GlyphRect)
  i724.m_Scale = i725[3]
  i724.m_AtlasIndex = i725[4]
  return i724
}

Deserializers["UnityEngine.TextCore.GlyphMetrics"] = function (request, data, root) {
  var i726 = root || request.c( 'UnityEngine.TextCore.GlyphMetrics' )
  var i727 = data
  i726.m_Width = i727[0]
  i726.m_Height = i727[1]
  i726.m_HorizontalBearingX = i727[2]
  i726.m_HorizontalBearingY = i727[3]
  i726.m_HorizontalAdvance = i727[4]
  return i726
}

Deserializers["UnityEngine.TextCore.GlyphRect"] = function (request, data, root) {
  var i728 = root || request.c( 'UnityEngine.TextCore.GlyphRect' )
  var i729 = data
  i728.m_X = i729[0]
  i728.m_Y = i729[1]
  i728.m_Width = i729[2]
  i728.m_Height = i729[3]
  return i728
}

Deserializers["TMPro.TMP_Character"] = function (request, data, root) {
  var i732 = root || request.c( 'TMPro.TMP_Character' )
  var i733 = data
  i732.m_ElementType = i733[0]
  i732.m_Unicode = i733[1]
  i732.m_GlyphIndex = i733[2]
  i732.m_Scale = i733[3]
  return i732
}

Deserializers["TMPro.FaceInfo_Legacy"] = function (request, data, root) {
  var i738 = root || request.c( 'TMPro.FaceInfo_Legacy' )
  var i739 = data
  i738.Name = i739[0]
  i738.PointSize = i739[1]
  i738.Scale = i739[2]
  i738.CharacterCount = i739[3]
  i738.LineHeight = i739[4]
  i738.Baseline = i739[5]
  i738.Ascender = i739[6]
  i738.CapHeight = i739[7]
  i738.Descender = i739[8]
  i738.CenterLine = i739[9]
  i738.SuperscriptOffset = i739[10]
  i738.SubscriptOffset = i739[11]
  i738.SubSize = i739[12]
  i738.Underline = i739[13]
  i738.UnderlineThickness = i739[14]
  i738.strikethrough = i739[15]
  i738.strikethroughThickness = i739[16]
  i738.TabWidth = i739[17]
  i738.Padding = i739[18]
  i738.AtlasWidth = i739[19]
  i738.AtlasHeight = i739[20]
  return i738
}

Deserializers["TMPro.TMP_Glyph"] = function (request, data, root) {
  var i742 = root || request.c( 'TMPro.TMP_Glyph' )
  var i743 = data
  i742.id = i743[0]
  i742.x = i743[1]
  i742.y = i743[2]
  i742.width = i743[3]
  i742.height = i743[4]
  i742.xOffset = i743[5]
  i742.yOffset = i743[6]
  i742.xAdvance = i743[7]
  i742.scale = i743[8]
  return i742
}

Deserializers["TMPro.KerningTable"] = function (request, data, root) {
  var i744 = root || request.c( 'TMPro.KerningTable' )
  var i745 = data
  var i747 = i745[0]
  var i746 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.KerningPair')))
  for(var i = 0; i < i747.length; i += 1) {
    i746.add(request.d('TMPro.KerningPair', i747[i + 0]));
  }
  i744.kerningPairs = i746
  return i744
}

Deserializers["TMPro.KerningPair"] = function (request, data, root) {
  var i750 = root || request.c( 'TMPro.KerningPair' )
  var i751 = data
  i750.xOffset = i751[0]
  i750.m_FirstGlyph = i751[1]
  i750.m_FirstGlyphAdjustments = request.d('TMPro.GlyphValueRecord_Legacy', i751[2], i750.m_FirstGlyphAdjustments)
  i750.m_SecondGlyph = i751[3]
  i750.m_SecondGlyphAdjustments = request.d('TMPro.GlyphValueRecord_Legacy', i751[4], i750.m_SecondGlyphAdjustments)
  i750.m_IgnoreSpacingAdjustments = !!i751[5]
  return i750
}

Deserializers["TMPro.TMP_FontFeatureTable"] = function (request, data, root) {
  var i752 = root || request.c( 'TMPro.TMP_FontFeatureTable' )
  var i753 = data
  var i755 = i753[0]
  var i754 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_GlyphPairAdjustmentRecord')))
  for(var i = 0; i < i755.length; i += 1) {
    i754.add(request.d('TMPro.TMP_GlyphPairAdjustmentRecord', i755[i + 0]));
  }
  i752.m_GlyphPairAdjustmentRecords = i754
  return i752
}

Deserializers["TMPro.TMP_GlyphPairAdjustmentRecord"] = function (request, data, root) {
  var i758 = root || request.c( 'TMPro.TMP_GlyphPairAdjustmentRecord' )
  var i759 = data
  i758.m_FirstAdjustmentRecord = request.d('TMPro.TMP_GlyphAdjustmentRecord', i759[0], i758.m_FirstAdjustmentRecord)
  i758.m_SecondAdjustmentRecord = request.d('TMPro.TMP_GlyphAdjustmentRecord', i759[1], i758.m_SecondAdjustmentRecord)
  i758.m_FeatureLookupFlags = i759[2]
  return i758
}

Deserializers["TMPro.TMP_GlyphAdjustmentRecord"] = function (request, data, root) {
  var i760 = root || request.c( 'TMPro.TMP_GlyphAdjustmentRecord' )
  var i761 = data
  i760.m_GlyphIndex = i761[0]
  i760.m_GlyphValueRecord = request.d('TMPro.TMP_GlyphValueRecord', i761[1], i760.m_GlyphValueRecord)
  return i760
}

Deserializers["TMPro.TMP_GlyphValueRecord"] = function (request, data, root) {
  var i762 = root || request.c( 'TMPro.TMP_GlyphValueRecord' )
  var i763 = data
  i762.m_XPlacement = i763[0]
  i762.m_YPlacement = i763[1]
  i762.m_XAdvance = i763[2]
  i762.m_YAdvance = i763[3]
  return i762
}

Deserializers["TMPro.FontAssetCreationSettings"] = function (request, data, root) {
  var i766 = root || request.c( 'TMPro.FontAssetCreationSettings' )
  var i767 = data
  i766.sourceFontFileName = i767[0]
  i766.sourceFontFileGUID = i767[1]
  i766.pointSizeSamplingMode = i767[2]
  i766.pointSize = i767[3]
  i766.padding = i767[4]
  i766.packingMode = i767[5]
  i766.atlasWidth = i767[6]
  i766.atlasHeight = i767[7]
  i766.characterSetSelectionMode = i767[8]
  i766.characterSequence = i767[9]
  i766.referencedFontAssetGUID = i767[10]
  i766.referencedTextAssetGUID = i767[11]
  i766.fontStyle = i767[12]
  i766.fontStyleModifier = i767[13]
  i766.renderMode = i767[14]
  i766.includeFontFeatures = !!i767[15]
  return i766
}

Deserializers["TMPro.TMP_FontWeightPair"] = function (request, data, root) {
  var i770 = root || request.c( 'TMPro.TMP_FontWeightPair' )
  var i771 = data
  request.r(i771[0], i771[1], 0, i770, 'regularTypeface')
  request.r(i771[2], i771[3], 0, i770, 'italicTypeface')
  return i770
}

Deserializers["UnityEngine.Tilemaps.Tile"] = function (request, data, root) {
  var i772 = root || request.c( 'UnityEngine.Tilemaps.Tile' )
  var i773 = data
  request.r(i773[0], i773[1], 0, i772, 'm_Sprite')
  i772.m_Color = new pc.Color(i773[2], i773[3], i773[4], i773[5])
  i772.m_Transform = new pc.Mat4().setData(i773[6], i773[7], i773[8], i773[9],  i773[10], i773[11], i773[12], i773[13],  i773[14], i773[15], i773[16], i773[17],  i773[18], i773[19], i773[20], i773[21])
  request.r(i773[22], i773[23], 0, i772, 'm_InstancedGameObject')
  i772.m_Flags = i773[24]
  i772.m_ColliderType = i773[25]
  return i772
}

Deserializers["TMPro.TMP_Settings"] = function (request, data, root) {
  var i774 = root || request.c( 'TMPro.TMP_Settings' )
  var i775 = data
  i774.m_enableWordWrapping = !!i775[0]
  i774.m_enableKerning = !!i775[1]
  i774.m_enableExtraPadding = !!i775[2]
  i774.m_enableTintAllSprites = !!i775[3]
  i774.m_enableParseEscapeCharacters = !!i775[4]
  i774.m_EnableRaycastTarget = !!i775[5]
  i774.m_GetFontFeaturesAtRuntime = !!i775[6]
  i774.m_missingGlyphCharacter = i775[7]
  i774.m_warningsDisabled = !!i775[8]
  request.r(i775[9], i775[10], 0, i774, 'm_defaultFontAsset')
  i774.m_defaultFontAssetPath = i775[11]
  i774.m_defaultFontSize = i775[12]
  i774.m_defaultAutoSizeMinRatio = i775[13]
  i774.m_defaultAutoSizeMaxRatio = i775[14]
  i774.m_defaultTextMeshProTextContainerSize = new pc.Vec2( i775[15], i775[16] )
  i774.m_defaultTextMeshProUITextContainerSize = new pc.Vec2( i775[17], i775[18] )
  i774.m_autoSizeTextContainer = !!i775[19]
  i774.m_IsTextObjectScaleStatic = !!i775[20]
  var i777 = i775[21]
  var i776 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i777.length; i += 2) {
  request.r(i777[i + 0], i777[i + 1], 1, i776, '')
  }
  i774.m_fallbackFontAssets = i776
  i774.m_matchMaterialPreset = !!i775[22]
  request.r(i775[23], i775[24], 0, i774, 'm_defaultSpriteAsset')
  i774.m_defaultSpriteAssetPath = i775[25]
  i774.m_enableEmojiSupport = !!i775[26]
  i774.m_MissingCharacterSpriteUnicode = i775[27]
  i774.m_defaultColorGradientPresetsPath = i775[28]
  request.r(i775[29], i775[30], 0, i774, 'm_defaultStyleSheet')
  i774.m_StyleSheetsResourcePath = i775[31]
  request.r(i775[32], i775[33], 0, i774, 'm_leadingCharacters')
  request.r(i775[34], i775[35], 0, i774, 'm_followingCharacters')
  i774.m_UseModernHangulLineBreakingRules = !!i775[36]
  return i774
}

Deserializers["TMPro.TMP_SpriteAsset"] = function (request, data, root) {
  var i778 = root || request.c( 'TMPro.TMP_SpriteAsset' )
  var i779 = data
  i778.hashCode = i779[0]
  request.r(i779[1], i779[2], 0, i778, 'material')
  i778.materialHashCode = i779[3]
  request.r(i779[4], i779[5], 0, i778, 'spriteSheet')
  var i781 = i779[6]
  var i780 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Sprite')))
  for(var i = 0; i < i781.length; i += 1) {
    i780.add(request.d('TMPro.TMP_Sprite', i781[i + 0]));
  }
  i778.spriteInfoList = i780
  var i783 = i779[7]
  var i782 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteAsset')))
  for(var i = 0; i < i783.length; i += 2) {
  request.r(i783[i + 0], i783[i + 1], 1, i782, '')
  }
  i778.fallbackSpriteAssets = i782
  i778.m_Version = i779[8]
  i778.m_FaceInfo = request.d('UnityEngine.TextCore.FaceInfo', i779[9], i778.m_FaceInfo)
  var i785 = i779[10]
  var i784 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteCharacter')))
  for(var i = 0; i < i785.length; i += 1) {
    i784.add(request.d('TMPro.TMP_SpriteCharacter', i785[i + 0]));
  }
  i778.m_SpriteCharacterTable = i784
  var i787 = i779[11]
  var i786 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteGlyph')))
  for(var i = 0; i < i787.length; i += 1) {
    i786.add(request.d('TMPro.TMP_SpriteGlyph', i787[i + 0]));
  }
  i778.m_SpriteGlyphTable = i786
  return i778
}

Deserializers["TMPro.TMP_Sprite"] = function (request, data, root) {
  var i790 = root || request.c( 'TMPro.TMP_Sprite' )
  var i791 = data
  i790.name = i791[0]
  i790.hashCode = i791[1]
  i790.unicode = i791[2]
  i790.pivot = new pc.Vec2( i791[3], i791[4] )
  request.r(i791[5], i791[6], 0, i790, 'sprite')
  i790.id = i791[7]
  i790.x = i791[8]
  i790.y = i791[9]
  i790.width = i791[10]
  i790.height = i791[11]
  i790.xOffset = i791[12]
  i790.yOffset = i791[13]
  i790.xAdvance = i791[14]
  i790.scale = i791[15]
  return i790
}

Deserializers["TMPro.TMP_SpriteCharacter"] = function (request, data, root) {
  var i796 = root || request.c( 'TMPro.TMP_SpriteCharacter' )
  var i797 = data
  i796.m_Name = i797[0]
  i796.m_HashCode = i797[1]
  i796.m_ElementType = i797[2]
  i796.m_Unicode = i797[3]
  i796.m_GlyphIndex = i797[4]
  i796.m_Scale = i797[5]
  return i796
}

Deserializers["TMPro.TMP_SpriteGlyph"] = function (request, data, root) {
  var i800 = root || request.c( 'TMPro.TMP_SpriteGlyph' )
  var i801 = data
  request.r(i801[0], i801[1], 0, i800, 'sprite')
  i800.m_Index = i801[2]
  i800.m_Metrics = request.d('UnityEngine.TextCore.GlyphMetrics', i801[3], i800.m_Metrics)
  i800.m_GlyphRect = request.d('UnityEngine.TextCore.GlyphRect', i801[4], i800.m_GlyphRect)
  i800.m_Scale = i801[5]
  i800.m_AtlasIndex = i801[6]
  return i800
}

Deserializers["TMPro.TMP_StyleSheet"] = function (request, data, root) {
  var i802 = root || request.c( 'TMPro.TMP_StyleSheet' )
  var i803 = data
  var i805 = i803[0]
  var i804 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Style')))
  for(var i = 0; i < i805.length; i += 1) {
    i804.add(request.d('TMPro.TMP_Style', i805[i + 0]));
  }
  i802.m_StyleList = i804
  return i802
}

Deserializers["TMPro.TMP_Style"] = function (request, data, root) {
  var i808 = root || request.c( 'TMPro.TMP_Style' )
  var i809 = data
  i808.m_Name = i809[0]
  i808.m_HashCode = i809[1]
  i808.m_OpeningDefinition = i809[2]
  i808.m_ClosingDefinition = i809[3]
  i808.m_OpeningTagArray = i809[4]
  i808.m_ClosingTagArray = i809[5]
  i808.m_OpeningTagUnicodeArray = i809[6]
  i808.m_ClosingTagUnicodeArray = i809[7]
  return i808
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Resources"] = function (request, data, root) {
  var i810 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Resources' )
  var i811 = data
  var i813 = i811[0]
  var i812 = []
  for(var i = 0; i < i813.length; i += 1) {
    i812.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Resources+File', i813[i + 0]) );
  }
  i810.files = i812
  i810.componentToPrefabIds = i811[1]
  return i810
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Resources+File"] = function (request, data, root) {
  var i816 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Resources+File' )
  var i817 = data
  i816.path = i817[0]
  request.r(i817[1], i817[2], 0, i816, 'unityObject')
  return i816
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings"] = function (request, data, root) {
  var i818 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings' )
  var i819 = data
  var i821 = i819[0]
  var i820 = []
  for(var i = 0; i < i821.length; i += 1) {
    i820.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder', i821[i + 0]) );
  }
  i818.scriptsExecutionOrder = i820
  var i823 = i819[1]
  var i822 = []
  for(var i = 0; i < i823.length; i += 1) {
    i822.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer', i823[i + 0]) );
  }
  i818.sortingLayers = i822
  var i825 = i819[2]
  var i824 = []
  for(var i = 0; i < i825.length; i += 1) {
    i824.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer', i825[i + 0]) );
  }
  i818.cullingLayers = i824
  i818.timeSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings', i819[3], i818.timeSettings)
  i818.physicsSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings', i819[4], i818.physicsSettings)
  i818.physics2DSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings', i819[5], i818.physics2DSettings)
  i818.qualitySettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.QualitySettings', i819[6], i818.qualitySettings)
  i818.enableRealtimeShadows = !!i819[7]
  i818.enableAutoInstancing = !!i819[8]
  i818.enableDynamicBatching = !!i819[9]
  i818.lightmapEncodingQuality = i819[10]
  i818.desiredColorSpace = i819[11]
  var i827 = i819[12]
  var i826 = []
  for(var i = 0; i < i827.length; i += 1) {
    i826.push( i827[i + 0] );
  }
  i818.allTags = i826
  return i818
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder"] = function (request, data, root) {
  var i830 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder' )
  var i831 = data
  i830.name = i831[0]
  i830.value = i831[1]
  return i830
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer"] = function (request, data, root) {
  var i834 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer' )
  var i835 = data
  i834.id = i835[0]
  i834.name = i835[1]
  i834.value = i835[2]
  return i834
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer"] = function (request, data, root) {
  var i838 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer' )
  var i839 = data
  i838.id = i839[0]
  i838.name = i839[1]
  return i838
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings"] = function (request, data, root) {
  var i840 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings' )
  var i841 = data
  i840.fixedDeltaTime = i841[0]
  i840.maximumDeltaTime = i841[1]
  i840.timeScale = i841[2]
  i840.maximumParticleTimestep = i841[3]
  return i840
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings"] = function (request, data, root) {
  var i842 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings' )
  var i843 = data
  i842.gravity = new pc.Vec3( i843[0], i843[1], i843[2] )
  i842.defaultSolverIterations = i843[3]
  i842.bounceThreshold = i843[4]
  i842.autoSyncTransforms = !!i843[5]
  i842.autoSimulation = !!i843[6]
  var i845 = i843[7]
  var i844 = []
  for(var i = 0; i < i845.length; i += 1) {
    i844.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask', i845[i + 0]) );
  }
  i842.collisionMatrix = i844
  return i842
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask"] = function (request, data, root) {
  var i848 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask' )
  var i849 = data
  i848.enabled = !!i849[0]
  i848.layerId = i849[1]
  i848.otherLayerId = i849[2]
  return i848
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings"] = function (request, data, root) {
  var i850 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings' )
  var i851 = data
  request.r(i851[0], i851[1], 0, i850, 'material')
  i850.gravity = new pc.Vec2( i851[2], i851[3] )
  i850.positionIterations = i851[4]
  i850.velocityIterations = i851[5]
  i850.velocityThreshold = i851[6]
  i850.maxLinearCorrection = i851[7]
  i850.maxAngularCorrection = i851[8]
  i850.maxTranslationSpeed = i851[9]
  i850.maxRotationSpeed = i851[10]
  i850.baumgarteScale = i851[11]
  i850.baumgarteTOIScale = i851[12]
  i850.timeToSleep = i851[13]
  i850.linearSleepTolerance = i851[14]
  i850.angularSleepTolerance = i851[15]
  i850.defaultContactOffset = i851[16]
  i850.autoSimulation = !!i851[17]
  i850.queriesHitTriggers = !!i851[18]
  i850.queriesStartInColliders = !!i851[19]
  i850.callbacksOnDisable = !!i851[20]
  i850.reuseCollisionCallbacks = !!i851[21]
  i850.autoSyncTransforms = !!i851[22]
  var i853 = i851[23]
  var i852 = []
  for(var i = 0; i < i853.length; i += 1) {
    i852.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask', i853[i + 0]) );
  }
  i850.collisionMatrix = i852
  return i850
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask"] = function (request, data, root) {
  var i856 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask' )
  var i857 = data
  i856.enabled = !!i857[0]
  i856.layerId = i857[1]
  i856.otherLayerId = i857[2]
  return i856
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.QualitySettings"] = function (request, data, root) {
  var i858 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.QualitySettings' )
  var i859 = data
  var i861 = i859[0]
  var i860 = []
  for(var i = 0; i < i861.length; i += 1) {
    i860.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.QualitySettings', i861[i + 0]) );
  }
  i858.qualityLevels = i860
  var i863 = i859[1]
  var i862 = []
  for(var i = 0; i < i863.length; i += 1) {
    i862.push( i863[i + 0] );
  }
  i858.names = i862
  i858.shadows = i859[2]
  i858.anisotropicFiltering = i859[3]
  i858.antiAliasing = i859[4]
  i858.lodBias = i859[5]
  i858.shadowCascades = i859[6]
  i858.shadowDistance = i859[7]
  i858.shadowmaskMode = i859[8]
  i858.shadowProjection = i859[9]
  i858.shadowResolution = i859[10]
  i858.softParticles = !!i859[11]
  i858.softVegetation = !!i859[12]
  i858.activeColorSpace = i859[13]
  i858.desiredColorSpace = i859[14]
  i858.masterTextureLimit = i859[15]
  i858.maxQueuedFrames = i859[16]
  i858.particleRaycastBudget = i859[17]
  i858.pixelLightCount = i859[18]
  i858.realtimeReflectionProbes = !!i859[19]
  i858.shadowCascade2Split = i859[20]
  i858.shadowCascade4Split = new pc.Vec3( i859[21], i859[22], i859[23] )
  i858.streamingMipmapsActive = !!i859[24]
  i858.vSyncCount = i859[25]
  i858.asyncUploadBufferSize = i859[26]
  i858.asyncUploadTimeSlice = i859[27]
  i858.billboardsFaceCameraPosition = !!i859[28]
  i858.shadowNearPlaneOffset = i859[29]
  i858.streamingMipmapsMemoryBudget = i859[30]
  i858.maximumLODLevel = i859[31]
  i858.streamingMipmapsAddAllCameras = !!i859[32]
  i858.streamingMipmapsMaxLevelReduction = i859[33]
  i858.streamingMipmapsRenderersPerFrame = i859[34]
  i858.resolutionScalingFixedDPIFactor = i859[35]
  i858.streamingMipmapsMaxFileIORequests = i859[36]
  i858.currentQualityLevel = i859[37]
  return i858
}

Deserializers["TMPro.GlyphValueRecord_Legacy"] = function (request, data, root) {
  var i866 = root || request.c( 'TMPro.GlyphValueRecord_Legacy' )
  var i867 = data
  i866.xPlacement = i867[0]
  i866.yPlacement = i867[1]
  i866.xAdvance = i867[2]
  i866.yAdvance = i867[3]
  return i866
}

Deserializers.fields = {"Luna.Unity.DTO.UnityEngine.Assets.Material":{"name":0,"shader":1,"renderQueue":3,"enableInstancing":4,"floatParameters":5,"colorParameters":6,"vectorParameters":7,"textureParameters":8,"materialFlags":9},"Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag":{"name":0,"enabled":1},"Luna.Unity.DTO.UnityEngine.Textures.Texture2D":{"name":0,"width":1,"height":2,"mipmapCount":3,"anisoLevel":4,"filterMode":5,"hdr":6,"format":7,"wrapMode":8,"alphaIsTransparency":9,"alphaSource":10},"Luna.Unity.DTO.UnityEngine.Components.RectTransform":{"pivot":0,"anchorMin":2,"anchorMax":4,"sizeDelta":6,"anchoredPosition3D":8,"rotation":11,"scale":15},"Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer":{"cullTransparentMesh":0},"Luna.Unity.DTO.UnityEngine.Scene.GameObject":{"name":0,"tagId":1,"enabled":2,"isStatic":3,"layer":4},"Luna.Unity.DTO.UnityEngine.Components.Canvas":{"enabled":0,"planeDistance":1,"referencePixelsPerUnit":2,"isFallbackOverlay":3,"renderMode":4,"renderOrder":5,"sortingLayerName":6,"sortingOrder":7,"scaleFactor":8,"worldCamera":9,"overrideSorting":11,"pixelPerfect":12,"targetDisplay":13,"overridePixelPerfect":14},"Luna.Unity.DTO.UnityEngine.Textures.Cubemap":{"name":0,"atlasId":1,"mipmapCount":2,"hdr":3,"size":4,"anisoLevel":5,"filterMode":6,"wrapMode":7,"rects":8},"Luna.Unity.DTO.UnityEngine.Scene.Scene":{"name":0,"index":1,"startup":2},"Luna.Unity.DTO.UnityEngine.Components.Transform":{"position":0,"scale":3,"rotation":6},"Luna.Unity.DTO.UnityEngine.Components.Camera":{"enabled":0,"aspect":1,"orthographic":2,"orthographicSize":3,"backgroundColor":4,"nearClipPlane":8,"farClipPlane":9,"fieldOfView":10,"depth":11,"clearFlags":12,"cullingMask":13,"rect":14,"targetTexture":15,"usePhysicalProperties":17,"focalLength":18,"sensorSize":19,"lensShift":21,"gateFit":23},"Luna.Unity.DTO.UnityEngine.Components.SpriteRenderer":{"enabled":0,"sharedMaterial":1,"sharedMaterials":3,"receiveShadows":4,"shadowCastingMode":5,"sortingLayerID":6,"sortingOrder":7,"lightmapIndex":8,"lightmapSceneIndex":9,"lightmapScaleOffset":10,"lightProbeUsage":14,"reflectionProbeUsage":15,"color":16,"sprite":20,"flipX":22,"flipY":23,"drawMode":24,"size":25,"tileMode":27,"adaptiveModeThreshold":28,"maskInteraction":29,"spriteSortPoint":30},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings":{"ambientIntensity":0,"reflectionIntensity":1,"ambientMode":2,"ambientLight":3,"ambientSkyColor":7,"ambientGroundColor":11,"ambientEquatorColor":15,"fogColor":19,"fogEndDistance":23,"fogStartDistance":24,"fogDensity":25,"fog":26,"skybox":27,"fogMode":29,"lightmaps":30,"lightProbes":31,"lightmapsMode":32,"mixedBakeMode":33,"environmentLightingMode":34,"ambientProbe":35,"referenceAmbientProbe":36,"useReferenceAmbientProbe":37,"customReflection":38,"defaultReflection":40,"defaultReflectionMode":42,"defaultReflectionResolution":43,"sunLightObjectId":44,"pixelLightCount":45,"defaultReflectionHDR":46,"hasLightDataAsset":47,"hasManualGenerate":48},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap":{"lightmapColor":0,"lightmapDirection":2},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes":{"bakedProbes":0,"positions":1,"hullRays":2,"tetrahedra":3,"neighbours":4,"matrices":5},"Luna.Unity.DTO.UnityEngine.Assets.Shader":{"invalidShaderVariants":0,"name":1,"guid":2,"shaderDefinedKeywords":3,"passes":4,"usePasses":5,"defaultParameterValues":6,"unityFallbackShader":7,"readDepth":9,"isCreatedByShaderGraph":10,"usedBatchUniforms":11},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass":{"id":0,"subShaderIndex":1,"name":2,"passType":3,"usePass":4,"zTest":5,"zWrite":6,"culling":7,"blending":8,"alphaBlending":9,"colorWriteMask":10,"offsetUnits":11,"offsetFactor":12,"stencilRef":13,"stencilReadMask":14,"stencilWriteMask":15,"stencilOp":16,"stencilOpFront":17,"stencilOpBack":18,"tags":19,"passDefinedKeywords":20,"passDefinedKeywordGroups":21,"variants":22,"excludedVariants":23,"hasDepthReader":24},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value":{"val":0,"name":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending":{"src":0,"dst":1,"op":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp":{"pass":0,"fail":1,"zFail":2,"comp":3},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup":{"keywords":0,"hasDiscard":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant":{"passId":0,"subShaderIndex":1,"keywords":2,"vertexProgram":3,"fragmentProgram":4,"readDepth":5},"Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass":{"shader":0,"pass":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue":{"name":0,"type":1,"value":2,"textureValue":6},"Luna.Unity.DTO.UnityEngine.Textures.Sprite":{"name":0,"texture":1,"aabb":3,"vertices":4,"triangles":5,"textureRect":6,"packedRect":10,"border":14,"transparency":18,"bounds":19,"pixelsPerUnit":20,"textureWidth":21,"textureHeight":22,"nativeSize":23,"pivot":25,"textureRectOffset":27},"Luna.Unity.DTO.UnityEngine.Assets.Font":{"name":0,"ascent":1,"originalLineHeight":2,"fontSize":3,"characterInfo":4,"texture":5,"originalFontSize":7},"Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo":{"index":0,"advance":1,"bearing":2,"glyphWidth":3,"glyphHeight":4,"minX":5,"maxX":6,"minY":7,"maxY":8,"uvBottomLeftX":9,"uvBottomLeftY":10,"uvBottomRightX":11,"uvBottomRightY":12,"uvTopLeftX":13,"uvTopLeftY":14,"uvTopRightX":15,"uvTopRightY":16},"Luna.Unity.DTO.UnityEngine.Assets.TextAsset":{"name":0,"bytes64":1,"data":2},"Luna.Unity.DTO.UnityEngine.Assets.Resources":{"files":0,"componentToPrefabIds":1},"Luna.Unity.DTO.UnityEngine.Assets.Resources+File":{"path":0,"unityObject":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings":{"scriptsExecutionOrder":0,"sortingLayers":1,"cullingLayers":2,"timeSettings":3,"physicsSettings":4,"physics2DSettings":5,"qualitySettings":6,"enableRealtimeShadows":7,"enableAutoInstancing":8,"enableDynamicBatching":9,"lightmapEncodingQuality":10,"desiredColorSpace":11,"allTags":12},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer":{"id":0,"name":1,"value":2},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer":{"id":0,"name":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings":{"fixedDeltaTime":0,"maximumDeltaTime":1,"timeScale":2,"maximumParticleTimestep":3},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings":{"gravity":0,"defaultSolverIterations":3,"bounceThreshold":4,"autoSyncTransforms":5,"autoSimulation":6,"collisionMatrix":7},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask":{"enabled":0,"layerId":1,"otherLayerId":2},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings":{"material":0,"gravity":2,"positionIterations":4,"velocityIterations":5,"velocityThreshold":6,"maxLinearCorrection":7,"maxAngularCorrection":8,"maxTranslationSpeed":9,"maxRotationSpeed":10,"baumgarteScale":11,"baumgarteTOIScale":12,"timeToSleep":13,"linearSleepTolerance":14,"angularSleepTolerance":15,"defaultContactOffset":16,"autoSimulation":17,"queriesHitTriggers":18,"queriesStartInColliders":19,"callbacksOnDisable":20,"reuseCollisionCallbacks":21,"autoSyncTransforms":22,"collisionMatrix":23},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask":{"enabled":0,"layerId":1,"otherLayerId":2},"Luna.Unity.DTO.UnityEngine.Assets.QualitySettings":{"qualityLevels":0,"names":1,"shadows":2,"anisotropicFiltering":3,"antiAliasing":4,"lodBias":5,"shadowCascades":6,"shadowDistance":7,"shadowmaskMode":8,"shadowProjection":9,"shadowResolution":10,"softParticles":11,"softVegetation":12,"activeColorSpace":13,"desiredColorSpace":14,"masterTextureLimit":15,"maxQueuedFrames":16,"particleRaycastBudget":17,"pixelLightCount":18,"realtimeReflectionProbes":19,"shadowCascade2Split":20,"shadowCascade4Split":21,"streamingMipmapsActive":24,"vSyncCount":25,"asyncUploadBufferSize":26,"asyncUploadTimeSlice":27,"billboardsFaceCameraPosition":28,"shadowNearPlaneOffset":29,"streamingMipmapsMemoryBudget":30,"maximumLODLevel":31,"streamingMipmapsAddAllCameras":32,"streamingMipmapsMaxLevelReduction":33,"streamingMipmapsRenderersPerFrame":34,"resolutionScalingFixedDPIFactor":35,"streamingMipmapsMaxFileIORequests":36,"currentQualityLevel":37}}

Deserializers.requiredComponents = {"47":[48],"49":[48],"50":[48],"51":[48],"52":[48],"53":[48],"54":[55],"56":[20],"57":[58],"59":[58],"60":[58],"61":[58],"62":[58],"63":[58],"64":[58],"65":[66],"67":[66],"68":[66],"69":[66],"70":[66],"71":[66],"72":[66],"73":[66],"74":[66],"75":[66],"76":[66],"77":[66],"78":[66],"79":[20],"80":[81],"33":[29],"82":[29],"14":[2],"83":[20],"84":[2],"85":[2],"16":[14],"5":[3,2],"86":[2],"15":[14],"87":[2],"7":[2],"88":[2],"89":[2],"90":[2],"91":[2],"92":[2],"93":[2],"94":[2],"95":[3,2],"96":[2],"97":[2],"98":[2],"24":[2],"99":[3,2],"100":[2],"101":[35],"102":[35],"36":[35],"103":[35],"104":[20],"105":[20],"106":[20],"107":[108],"109":[2],"110":[81,2],"11":[2,3],"111":[2],"112":[3,2],"113":[81],"114":[3,2],"115":[2],"116":[117],"118":[117],"119":[37],"120":[27],"121":[117]}

Deserializers.types = ["UnityEngine.Shader","UnityEngine.Texture2D","UnityEngine.RectTransform","UnityEngine.CanvasRenderer","UnityEngine.EventSystems.UIBehaviour","UnityEngine.UI.Image","UnityEngine.Sprite","UnityEngine.UI.GridLayoutGroup","UnityEngine.UI.Button","UnityEngine.MonoBehaviour","GetColorButton","TMPro.TextMeshProUGUI","TMPro.TMP_FontAsset","UnityEngine.Material","UnityEngine.Canvas","UnityEngine.UI.CanvasScaler","UnityEngine.UI.GraphicRaycaster","StatsRecord","UnityEngine.GameObject","UnityEngine.Transform","UnityEngine.Camera","UnityEngine.AudioListener","Cinemachine.CinemachineBrain","CammeraMove","UnityEngine.UI.Slider","Cinemachine.CinemachineVirtualCamera","UnityEngine.Grid","UnityEngine.U2D.SpriteShapeRenderer","GameManager","UnityEngine.Tilemaps.Tilemap","UnityEngine.Tilemaps.Tile","PageColorSwipe","FillPixel","UnityEngine.Tilemaps.TilemapRenderer","ChosseStatusBtn","UnityEngine.EventSystems.EventSystem","UnityEngine.EventSystems.StandaloneInputModule","UnityEngine.SpriteRenderer","Cinemachine.CinemachinePipeline","Cinemachine.CinemachineComposer","Cinemachine.CinemachineFramingTransposer","UnityEngine.Cubemap","UnityEngine.Font","TMPro.TMP_Settings","TMPro.TMP_SpriteAsset","TMPro.TMP_StyleSheet","UnityEngine.TextAsset","UnityEngine.AudioLowPassFilter","UnityEngine.AudioBehaviour","UnityEngine.AudioHighPassFilter","UnityEngine.AudioReverbFilter","UnityEngine.AudioDistortionFilter","UnityEngine.AudioEchoFilter","UnityEngine.AudioChorusFilter","UnityEngine.Cloth","UnityEngine.SkinnedMeshRenderer","UnityEngine.FlareLayer","UnityEngine.ConstantForce","UnityEngine.Rigidbody","UnityEngine.Joint","UnityEngine.HingeJoint","UnityEngine.SpringJoint","UnityEngine.FixedJoint","UnityEngine.CharacterJoint","UnityEngine.ConfigurableJoint","UnityEngine.CompositeCollider2D","UnityEngine.Rigidbody2D","UnityEngine.Joint2D","UnityEngine.AnchoredJoint2D","UnityEngine.SpringJoint2D","UnityEngine.DistanceJoint2D","UnityEngine.FrictionJoint2D","UnityEngine.HingeJoint2D","UnityEngine.RelativeJoint2D","UnityEngine.SliderJoint2D","UnityEngine.TargetJoint2D","UnityEngine.FixedJoint2D","UnityEngine.WheelJoint2D","UnityEngine.ConstantForce2D","UnityEngine.StreamingController","UnityEngine.TextMesh","UnityEngine.MeshRenderer","UnityEngine.Tilemaps.TilemapCollider2D","UnityEngine.U2D.PixelPerfectCamera","UnityEngine.UI.Dropdown","UnityEngine.UI.Graphic","UnityEngine.UI.AspectRatioFitter","UnityEngine.UI.ContentSizeFitter","UnityEngine.UI.HorizontalLayoutGroup","UnityEngine.UI.HorizontalOrVerticalLayoutGroup","UnityEngine.UI.LayoutElement","UnityEngine.UI.LayoutGroup","UnityEngine.UI.VerticalLayoutGroup","UnityEngine.UI.Mask","UnityEngine.UI.MaskableGraphic","UnityEngine.UI.RawImage","UnityEngine.UI.RectMask2D","UnityEngine.UI.Scrollbar","UnityEngine.UI.ScrollRect","UnityEngine.UI.Text","UnityEngine.UI.Toggle","UnityEngine.EventSystems.BaseInputModule","UnityEngine.EventSystems.PointerInputModule","UnityEngine.EventSystems.TouchInputModule","UnityEngine.EventSystems.Physics2DRaycaster","UnityEngine.EventSystems.PhysicsRaycaster","Cinemachine.CinemachineExternalCamera","Cinemachine.GroupWeightManipulator","Cinemachine.CinemachineTargetGroup","TMPro.TextContainer","TMPro.TextMeshPro","TMPro.TMP_Dropdown","TMPro.TMP_SelectionCaret","TMPro.TMP_SubMesh","TMPro.TMP_SubMeshUI","TMPro.TMP_Text","Unity.VisualScripting.ScriptMachine","Unity.VisualScripting.Variables","Unity.VisualScripting.SceneVariables","UnityEngine.U2D.Animation.SpriteSkin","UnityEngine.U2D.SpriteShapeController","Unity.VisualScripting.StateMachine"]

Deserializers.unityVersion = "2021.3.7f1";

Deserializers.productName = "optimization PixelArt";

Deserializers.lunaInitializationTime = "08/03/2023 08:38:56";

Deserializers.lunaDaysRunning = "0.0";

Deserializers.lunaVersion = "5.2.0";

Deserializers.lunaSHA = "a655a1e01be315dbfa8d2e1b74c75f56b0112281";

Deserializers.creativeName = "";

Deserializers.lunaAppID = "17555";

Deserializers.projectId = "543530ab20db80349b3d6af2dd61ac32";

Deserializers.packagesInfo = "com.unity.cinemachine: 2.8.9\ncom.unity.textmeshpro: 3.0.6\ncom.unity.timeline: 1.6.4\ncom.unity.ugui: 1.0.0";

Deserializers.externalJsLibraries = "";

Deserializers.androidLink = ( typeof window !== "undefined")&&window.$environment.packageConfig.androidLink?window.$environment.packageConfig.androidLink:'Empty';

Deserializers.iosLink = ( typeof window !== "undefined")&&window.$environment.packageConfig.iosLink?window.$environment.packageConfig.iosLink:'Empty';

Deserializers.base64Enabled = "False";

Deserializers.minifyEnabled = "True";

Deserializers.isForceUncompressed = "False";

Deserializers.isAntiAliasingEnabled = "False";

Deserializers.isRuntimeAnalysisEnabledForCode = "False";

Deserializers.runtimeAnalysisExcludedClassesCount = "1536";

Deserializers.runtimeAnalysisExcludedMethodsCount = "3558";

Deserializers.runtimeAnalysisExcludedModules = "physics3d, physics2d, particle-system, reflection, prefabs";

Deserializers.isRuntimeAnalysisEnabledForShaders = "True";

Deserializers.isRealtimeShadowsEnabled = "False";

Deserializers.isReferenceAmbientProbeBaked = "False";

Deserializers.isLunaCompilerV2Used = "False";

Deserializers.companyName = "DefaultCompany";

Deserializers.buildPlatform = "Android";

Deserializers.applicationIdentifier = "com.DefaultCompany.optimizationPixelArt";

Deserializers.disableAntiAliasing = true;

Deserializers.buildID = "851151ef-4fa1-4312-b360-036911f6bf02";

Deserializers.typeNameToIdMap = function(){ var i = 0; return Deserializers.types.reduce( function( res, item ) { res[ item ] = i++; return res; }, {} ) }()

