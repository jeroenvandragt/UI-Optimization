This Git is made for EasySee b.v.

Due to a project for the Oculus Quest 2, the limitations of the headset became clear when designing World-Space User Interfaces. 
With a budget of 50-100 draw calls per frame (on a heavy simulation, which we will assume that this project will be), 30 draw calls per world-space UI is way too much, and needs to be optimized.

On the EasySee Confluence page a document can be found with tips and tricks to use when designing user interfaces for VR applications.

Topics include:
- The Power of Two
- Draw Call Batching
- Object Pooling
- Raycast Target
- UI Design
  - Hierarchy structure
- Slicing
- Animations
- EventCamera
- Masking
