# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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


