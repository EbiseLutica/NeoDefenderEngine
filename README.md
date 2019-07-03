# NeoDefenderEngine

This project is a port of Defender Engine v0.3.0 built with DotFeather.

This project's goal is
    - To be readable and maintainable
    - The game `Take Up Jewel` runs completely
    - To be cross-platform

Defender Engine is built with DX Library, a DirectX wrapper library which is famous in Japan, but it only supports Windows (because it's based on DirectX). NeoDefenderEngine uses [DotFeather](https://github.com/xeltica/dotfeather). It's a game engine developed and maintained by me. It's cross-platform and very lightweight.

Defender Engine uses "MusicSheet" synthesizer to play MIDI file, but it depends Windows & DX Library. Therefore I use Groorine instead. They are both my original midi synthesizer, but Groorine is portable, and has high compatibility with MusicSheet.

------

このプロジェクトは、 Defender Engine v0.3.0 の DotFeather を用いた移植です。

このプロジェクトのゴールは3つあります。
- より読みやすく、メンテナンスしやすいコード
- Take Up Jewel を完璧に移植させる
- クロスプラットフォームである

Defender Engine は、DXライブラリをベースに構築されています。しかしながら、DXライブラリは DirectX のラッパーライブラリである為、Windowsでしか動作しません。 NeoDefenderEngine は [DotFeather](https://github.com/xeltica/dotfeather) を使用しています。 DotFeather は私が開発・メンテナンスしているゲームエンジンで、クロスプラットフォームであり、軽量です。

Defender Engine は 「MusicSheet」シンセサイザーを用いて MIDI の再生を行っています。しかしながら、 MusicSheet は Windows およびDXライブラリに依存している為使用できません。代わりに Groorine を採用しました。どちらとも私が開発したMIDIシンセサイザーですが、Groorineは移植性が高く、また MusicSheet と高い互換性を持っています。

## License

[MIT](LICENSE)