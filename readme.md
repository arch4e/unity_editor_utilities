# Unity Editor Utilities


## Description

### Create animation clips

#### Feature

- Detects SkinnedMeshRenderer components from the selected GameObject and its children
- Automatically generates .anim files for each blend shape found in the detected SkinnedMeshRenderers
- Created animation clips set the target blend shape value to 100

#### Usage

- Right-click in the Hierarchy window and select "Animation >> Create animation clips"
  - Generated animation files are saved in the "Assets/Exports/" folder
  - The folder will be automatically created if it doesn't exist
  - Each animation clip is saved with the corresponding blend shape name


## License

GPLv3
