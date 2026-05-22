# Ondular VR

A real-scale **virtual reality apartment experience** developed in **Unity** for **Meta Quest 2**, created for the **Ondular** real estate development by **Woss**, a high-end construction company from Rio Grande do Sul, Brazil.

The project was designed as an immersive architectural visualization tool, allowing users to explore the apartment in real scale through standalone VR, real-time rendering, optimized 3D environments, spatial media, and custom teleport locomotion.

---

## Overview

**Ondular VR** is an interactive real estate VR experience built to present a premium residential development in an immersive and spatially accurate way.

Instead of relying only on static renders, videos, floor plans, or traditional 360° tours, the application allows the user to enter the apartment virtually, move through the rooms, perceive scale, observe architectural details, and experience the ambience of the property as if physically present.

The project was used in real estate presentation contexts and events as a premium visualization tool for client demonstrations.

---

## Client

Developed for **Woss**, a high-end real estate developer and construction company from Rio Grande do Sul, Brazil.

---

## Main Features

- Real-scale VR apartment visualization
- Standalone Meta Quest 2 support
- Unity real-time rendering
- Universal Render Pipeline, also known as URP
- Optimized PBR materials
- Baked lightmapping for high-quality lighting
- Optimized 3D models and meshes
- Occlusion culling for performance
- Polygon budget control for Quest 2
- Free teleport locomotion
- Hand-based teleport interaction
- Pointer-based teleport interaction
- Meta SDK hand pose detection
- Custom hand teleport system developed from scratch
- Safety checks to avoid crossing walls or invalid movement areas
- Raycast-based teleport validation
- Spatial audio for ambience and immersion
- Video playback on in-scene TVs
- Drone-captured apartment views
- Event-ready VR experience

---

## Technical Goals

The main technical goal of the project was to deliver a visually polished, real-scale architectural experience while respecting the limitations of standalone VR hardware.

The application was developed for **Meta Quest 2**, requiring strict optimization of geometry, lighting, materials, visibility, and runtime rendering cost.

A maximum target of approximately:

```txt
1,000,000 rendered polygons per frame on Meta Quest 2
```

was used as a practical performance guideline during development.

This influenced the way assets were modeled, optimized, organized, rendered, and culled inside Unity.
The framerate was perfect all the time. No performance issues were detected.
---

## Rendering Pipeline

The project uses **Unity** with the **Universal Render Pipeline**.

URP was chosen for its balance between visual quality and performance on standalone VR devices. The scene was prepared with real-time rendering constraints in mind, while relying on baked lighting and optimized assets to maintain visual quality.

The rendering workflow included:

- URP configuration
- PBR material setup
- Lightmap baking
- Global illumination through baked lighting
- Optimized shader and material usage
- Mesh simplification
- Texture optimization
- Occlusion culling
- Performance-aware scene composition

---

## Lighting

Lighting was a central part of the visual experience.

Because standalone VR hardware has limited performance for expensive real-time lighting, the project uses baked lighting through lightmaps. This allows the apartment to preserve a high-quality visual atmosphere while reducing runtime rendering cost.

The lighting workflow included:

- Static lighting setup
- Baked global illumination
- Lightmap preparation
- Interior ambience balancing
- Performance-conscious light usage
- Consistent visual mood across rooms

---

## 3D Asset Optimization

The apartment environment was modeled and optimized specifically for standalone VR usage.

The assets were created according to the architectural and visual references established by Woss, while being adapted for real-time rendering constraints.

The optimization process included:

- Clean mesh construction
- Polygon reduction where appropriate
- Real-time-ready model preparation
- PBR material setup
- UV organization
- Lightmap UV preparation
- Scene hierarchy organization
- Object grouping for visibility control
- Optimization based on Quest 2 performance limits

---

## Locomotion System

The project includes a free teleport locomotion system designed for intuitive VR navigation.

Users can move through the apartment by aiming at valid areas and teleporting to the selected location.

The locomotion system supports two interaction styles:

### Pointer Teleport

The user points toward the desired destination and confirms the teleport movement.

### Hand-Line Teleport

A visual line is projected from the user’s hand, allowing the user to aim naturally using hand movement.

Both systems are connected to **Meta SDK hand pose detection**, enabling teleport activation based on recognized hand poses.

---

## Custom Hand Teleport System

The hand teleport system was developed from scratch.

When the required hand pose is detected, the system sends an internal signal requesting teleport validation. Before moving the player, the application checks whether the target location is valid and safe.

The teleport flow follows this logic:

1. Detect the user’s hand pose.
2. Send a teleport request.
3. Cast validation checks toward the target area.
4. Verify whether the user is allowed to move.
5. Prevent movement through walls or invalid spaces.
6. Move the player rig only after successful validation.

This system was created to make movement feel natural while maintaining spatial safety inside the apartment.

---

## Safety and Movement Validation

Several checks were implemented to prevent invalid locomotion behavior.

The goal was to avoid situations where the user could teleport through walls, leave the apartment boundaries, clip through geometry, or move into inaccessible areas.

The validation system included:

- Raycast distance checks
- Destination validation
- Surface detection
- Wall crossing prevention
- Movement permission logic
- Player rig relocation only after successful validation

---

## Spatial Audio and Media

The project includes spatial audio elements to increase immersion inside the apartment.

Sound was used to make the environment feel more alive and present, reinforcing the sense of being inside a real physical space.

The project also includes video playback on TVs inside the apartment, adding another layer of realism and ambience to the experience.

Apartment views were captured using drones, allowing exterior landscape references to be integrated into the virtual presentation.

---

## Real-Scale Architectural Experience

A major goal of the project was to preserve the real spatial scale of the apartment.

In real estate visualization, scale is one of the most important aspects of the experience. VR allows users to understand the property spatially instead of only visually.

The experience helps users perceive:

- Room proportions
- Circulation space
- Furniture placement
- Window views
- Ceiling height perception
- Spatial relationships between rooms
- Overall apartment atmosphere

---

## Performance Strategy

Because the application was designed for standalone Meta Quest 2 usage, performance optimization was part of the entire production process.

The project used a combination of:

- Polygon budget control
- Mesh optimization
- PBR material optimization
- Baked lighting
- Occlusion culling
- Texture optimization
- Reduced runtime lighting cost
- Careful object visibility management
- Optimized scene hierarchy

The goal was to maintain visual quality while keeping the experience stable and comfortable in VR.

---

## Target Platform

The primary target platform is:

```txt
Meta Quest 2
```

The application was developed for standalone VR usage, meaning it runs directly on the headset without requiring a connected PC during the experience.

---

## Technologies Used

- Unity
- C#
- Universal Render Pipeline
- Meta Quest 2
- Meta SDK
- Meta XR interaction systems
- Hand tracking
- Pose detection
- Real-time rendering
- PBR materials
- Lightmapping
- Occlusion culling
- Spatial audio
- Video playback inside Unity
- Drone-captured visual references

---

## Repository Notes

This repository is intended for portfolio visualization and technical demonstration only.

Some assets may be excluded or partially modified due to:

- Client confidentiality
- File size limitations
- Real estate project rights
- Commercial asset licensing
- Construction company references
- Internal production material
- GitHub repository size best practices

Production assets should not be redistributed without permission.

---

## Credits

### Development

- **VR Development:** Felipe Buchabqui Saenger Marzanaco
- **3D Art and Optimization:** Felipe Marzanasco / RAS Soluções Metaversificadas
- **Unity Implementation:** Felipe Marzanasco / RAS Soluções Metaversificadas

### Client

- **Woss**

### Project

- **Ondular**

### Location
-**Porto Alegre / Rio Grande do Sul /  Brazil

---

## Usage Rights

This repository is provided strictly for **portfolio review and technical visualization**.

The code, assets, models, scenes, materials, interaction systems, and project structure may not be copied, redistributed, resold, reused, modified, or used commercially without explicit written permission.

All rights are reserved by the respective creators, developers, clients, and asset owners.

This repository does not grant permission to reproduce the project, reuse the VR systems, extract assets, or use any client-related material outside of portfolio evaluation.

---

## License

```txt
All Rights Reserved.

This project is not open-source.
Available for portfolio viewing only.
Copying, redistribution, reuse, modification, or commercial use is prohibited without explicit permission.
```
