# Unity Tool Kit


## Description

### Create .anim files

#### Feature

- Detects SkinnedMeshRenderer components from the selected GameObject and its children
- Automatically generates .anim files for each blend shape found in the detected SkinnedMeshRenderers
- Created animation clips set the target blend shape value to 100

#### Usage

- Right-click in the Hierarchy window and select "Unity Tool Kit >> Create .anim files"
  - Generated animation files are saved in the "Assets/Exports/" folder
  - The folder will be automatically created if it doesn't exist
  - Each .anim file is saved with the corresponding blend shape name


## License

GPLv3

