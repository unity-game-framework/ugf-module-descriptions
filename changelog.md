# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0-preview.1](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/3.0.0-preview.1) - 2024-08-17  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/20?closed=1)  
    

### Changed

- Change description table ([#44](https://github.com/unity-game-framework/ugf-module-descriptions/issues/44))  
    - Change `DescriptionTableAsset` and related classes to be define as single `TableAsset` instead of a collection.

## [3.0.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/3.0.0-preview) - 2024-08-15  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/19?closed=1)  
    

### Added

- Add description table ([#33](https://github.com/unity-game-framework/ugf-module-descriptions/issues/33))  
    - Update dependencies: `com.ugf.module.assets` to `6.0.0-preview.2`, add `com.ugf.tables` of `1.0.0-preview.1` version.
    - Add `DescriptionTable` and related classes to define _Table_ with entry as description builders.
    - Change `DescriptionModule` and related classes to support updated _Application_ package.

## [2.2.0-preview.1](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/2.2.0-preview.1) - 2023-11-23  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/18?closed=1)  
    

### Changed

- Change to use UGF.Assets package ([#41](https://github.com/unity-game-framework/ugf-module-descriptions/issues/41))  
    - Update dependencies: `com.ugf.module.assets` to `6.0.0-preview.1` version.

## [2.2.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/2.2.0-preview) - 2023-11-17  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/17?closed=1)  
    

### Changed

- Change description folders to use asset folders ([#39](https://github.com/unity-game-framework/ugf-module-descriptions/issues/39))  
    - Update dependencies: `com.ugf.module.assets` to `6.0.0-preview` version.
    - Update package _Unity_ version to `2023.2`.
    - Add `DescriptionCollectionListFolderAsset` class as asset folder implementation for `DescriptionAsset` assets.
    - Remove `DescriptionFolderAsset` and related classes, use asset folders instead.

## [2.1.0-preview.1](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/2.1.0-preview.1) - 2023-11-15  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/16?closed=1)  
    

### Added

- Add description folder auto update project settings option ([#37](https://github.com/unity-game-framework/ugf-module-descriptions/issues/37))  
    - Add `DescriptionEditorSettings.FoldersAutoUpdate` property to control folders auto update during asset post processing.
    - Add `DescriptionEditorSettingsData.FoldersAutoUpdate` property which can be changed in project settings.

## [2.1.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/2.1.0-preview) - 2023-11-13  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/15?closed=1)  
    

### Added

- Add description collection from folder ([#35](https://github.com/unity-game-framework/ugf-module-descriptions/issues/35))  
    - Update package _Unity_ version to `2023.1`.
    - Update package registry to _UPM Hub_.
    - Add `DescriptionFolderAsset` class as asset to define auto updated description collections linked to a folder with description assets inside.
    - Add `DescriptionEditorSettings` class and project settings for `DescriptionFolderAsset` assets to be registered for auto or manual update.
    - Add `DescriptionFolderEditorUtility` class to work with description folders.

## [2.0.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/2.0.0-preview) - 2023-06-28  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/14?closed=1)  
    

### Added

- Add description asset loading ([#32](https://github.com/unity-game-framework/ugf-module-descriptions/issues/32))  
    - Update dependencies: `com.ugf.application` to `8.5.0` and `com.ugf.editortools` to `2.17.0` versions, add `com.ugf.module.assets` of `5.1.0` version.
    - Update package _Unity_ version to `2022.3`.
    - Add `IDescriptionModule.LoadFromAssetsAsync()` method to load description data from assets.
    - Add `IDescriptionModule.Provider` property as provider for description data.
    - Add `DescriptionModuleDescription.LoadAsync` property as collection of description to load on initialize.
    - Add `DescriptionCollectionAsset.GetDescriptions()` method to get descriptions into specified provider.
    - Add `DescriptionGroupAsset.Descriptions` inspector property drag and drop adding support.
    - Change `DescriptionCollectionDescription`, `DescriptionGroup` and `DescriptionModuleDescription` descriptions classes to read only.

## [1.0.0](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/1.0.0) - 2023-01-04  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/13?closed=1)  
    

### Changed

- Update project ([#30](https://github.com/unity-game-framework/ugf-module-descriptions/issues/30))  
    - Update dependencies: `com.ugf.editortools` to `2.15.0` version.

## [1.0.0-preview.5](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/1.0.0-preview.5) - 2022-12-12  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/12?closed=1)  
    

### Fixed

- Fix DescriptionGroupAsset nested collection ([#27](https://github.com/unity-game-framework/ugf-module-descriptions/issues/27))  
    - Add `DescriptionGroupAsset.GetDescriptions()` method to collect description ids.
    - Fix `DescriptionGroupAsset` class to properly collection nested groups.

## [1.0.0-preview.4](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/1.0.0-preview.4) - 2022-12-12  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/11?closed=1)  
    

### Added

- Add list selection support id collections ([#25](https://github.com/unity-game-framework/ugf-module-descriptions/issues/25))  
    - Update dependencies: `com.ugf.application` to `8.4.0` and `com.ugf.editortools` to `2.14.0` versions.
    - Update package _Unity_ version to `2022.2`.
    - Add `DescriptionGroupAsset` class to support selection preview in inspector.

## [1.0.0-preview.3](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/1.0.0-preview.3) - 2022-12-03  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/10?closed=1)  
    

### Added

- Add description collection list nested support ([#23](https://github.com/unity-game-framework/ugf-module-descriptions/issues/23))  
    - Change `DescriptionCollectionListAsset` class to support nested `DescriptionCollectionAsset` instances.

## [1.0.0-preview.2](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/1.0.0-preview.2) - 2022-11-11  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/9?closed=1)  
    

### Added

- Add description group collections ([#21](https://github.com/unity-game-framework/ugf-module-descriptions/issues/21))  
    - Add `DescriptionGroupAsset.Groups` property as collection of nested `DescriptionGroupAsset` assets.

## [1.0.0-preview.1](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/1.0.0-preview.1) - 2022-11-11  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/8?closed=1)  
    

### Changed

- Change description collection to description asset ([#18](https://github.com/unity-game-framework/ugf-module-descriptions/issues/18))  
    - Add `DescriptionCollectionDescription` class as description of collection.
    - Change `DescriptionCollectionAsset` class to inherit from the `DescriptionAsset` class.
    - Change `DescriptionCollectionListAsset` class to build `DescriptionCollectionDescription` as description.

### Fixed

- Fix missing IDescriptionModuleDescription members ([#17](https://github.com/unity-game-framework/ugf-module-descriptions/issues/17))  
    - Fix `IDescriptionModuleDescription.Descriptions` missing member.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/1.0.0-preview) - 2022-11-10  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/7?closed=1)  
    

### Added

- Rework package ([#15](https://github.com/unity-game-framework/ugf-module-descriptions/issues/15))  
    - Update dependencies: `com.ugf.application` to `8.3.1` and `com.ugf.editortools` to `2.13.0` versions, remove of `com.ugf.module.assets` and `com.ugf.module.serialize` packages.
    - Update package _Unity_ version to `2022.1`.
    - Update package _API Compatibility_ version to `.NET Standard 2.1`.
    - Add `DescriptionAsset` an abstract class as default implementation of description asset.
    - Add `DescriptionCollectionListAsset` class to store description assets in collection.
    - Add `DescriptionGroup` class to define description relations.
    - Change `IDescriptionModule` and related classes to be implemented to store descriptions, instead of the loading and deserializing them.

## [0.6.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/0.6.0-preview) - 2020-02-02  

- [Commits](https://github.com/unity-game-framework/ugf-module-descriptions/compare/0.5.0-preview...0.6.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/6?closed=1)

### Added
- Package dependencies:
    - `com.ugf.editortools`: `0.5.0-preview`.

### Changed
- Rework module to store and load description asset ids without names.

## [0.5.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/0.5.0-preview) - 2020-01-26  

- [Commits](https://github.com/unity-game-framework/ugf-module-descriptions/compare/0.4.0-preview...0.5.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/5?closed=1)

### Changed
- Package dependencies:
    - `com.ugf.application`: from `3.1.0-preview` to `4.0.0-preview`.

## [0.4.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/0.4.0-preview) - 2020-01-11  

- [Commits](https://github.com/unity-game-framework/ugf-module-descriptions/compare/0.3.0-preview...0.4.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/4?closed=1)

### Changed
- Package dependencies:
    - `com.ugf.logs`: from `1.1.0` to `2.0.0`.
- Descriptions loading and extracting logic.

## [0.3.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/0.3.0-preview) - 2019-12-10  

- [Commits](https://github.com/unity-game-framework/ugf-module-descriptions/compare/0.2.0-preview...0.3.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/3?closed=1)

### Changed
- Package dependencies:
    - `com.ugf.module.assets`: from `0.2.0-preview` to `0.3.0-preview`.
    - `com.ugf.module.serialize`: from `0.1.0-preview` to `0.3.0-preview`.
- Update `UGF.Application` package.

## [0.2.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/0.2.0-preview) - 2019-11-19  

- [Commits](https://github.com/unity-game-framework/ugf-module-descriptions/compare/0.1.0-preview...0.2.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/2?closed=1)

### Changed
- Package dependencies:
    - `com.ugf.module.assets`: from `0.1.0-preview` to `0.2.0-preview`.
- Rework module to use async / await.

## [0.1.0-preview](https://github.com/unity-game-framework/ugf-module-descriptions/releases/tag/0.1.0-preview) - 2019-10-09  

- [Commits](https://github.com/unity-game-framework/ugf-module-descriptions/compare/7c38a7f...0.1.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-module-descriptions/milestone/1?closed=1)

### Added
- This is a initial release.


