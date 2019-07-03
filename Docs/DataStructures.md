# Defender Story メモ
<small>(C)2014-2015 Citringo All rights reserved.</small><br>
<small>(C)2019 Xeltica All rights reserved.</small>


+ 📁Level
	+ 📁Area
		+ 📄blockdata.citmap
		+ 📄spdata.json
		+ 📄area.json
	+ 📄lvldat.json

Level ディレクトリは、レベル番号のみ書く。

Area ディレクトリも、Area 番号のみ書く。

## citchip仕様

マップチップの情報だけなのでそんなに難しくない

|データ|バイト数|備考|
|-----|-------|---|
|"CITCHIP"|7|マジックナンバー|
|幅|32|
|高さ|32|
|チップデータ|幅\*高さ*2||

## spdata 記法

```json
{
	"spdata":
	[
		"ここにエンティティのメタデータ"
	]
}
```

## area 記法
一応まだ仮
仕様が変わるかも

```json
{
	"Mpt" : "0",
	"Music" : "散歩.mid",
	"BG" : "overground.png",
	"ScrollSpeed": 10
}
```

## lvldat 記法

```json
{
	"FirstArea" : 0
}
```