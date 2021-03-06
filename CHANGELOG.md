# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.4.0] - 2022-02-27

### Changed

- More optimized attempt at ensuring `GetHashCode()` implementation now should respect value comparisons rather than proxying directly down to `Object.GetHashCode()`.

## [0.3.0] - 2022-02-25

### Changed

- Reverted the last change related to `GetHashCode()`. We can revisit this in the future, but for now it makes things insanely slow.

## [0.2.0] - 2022-02-25

### Changed

- `GetHashCode()` implementation now should respect value comparisons rather than proxying directly down to `Object.GetHashCode()`.

## [0.1.0] - 2022-02-21

### Added

- Initial release!

[0.4.0]: https://github.com/RealGoodAppsLLC/ExpressionMagic/releases/tag/v0.4.0
[0.3.0]: https://github.com/RealGoodAppsLLC/ExpressionMagic/releases/tag/v0.3.0
[0.2.0]: https://github.com/RealGoodAppsLLC/ExpressionMagic/releases/tag/v0.2.0
[0.1.0]: https://github.com/RealGoodAppsLLC/ExpressionMagic/releases/tag/v0.1.0
