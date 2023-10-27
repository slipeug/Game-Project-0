﻿using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework;

using TInput = System.String;
using TOutput = System.String;

namespace TilemapPipeline
{
    [ContentProcessor(DisplayName = "TilemapProcessor")]
    internal class TilemapProcessor : ContentProcessor<TilemapContent, TilemapContent>
    {
        /// <summary>
        /// A scaling parameter to make the tilemap bigger
        /// </summary>
        public float Scale { get; set; } = 1.0f;
        public override TilemapContent Process(TilemapContent map, ContentProcessorContext context)
        {
            // We need to build the tileset texture associated with this tilemap
            // This will create the binary texture file and link it to this tilemap so 
            // they get loaded together by the ContentProcessor.  
            //map.TilesetTexture = context.BuildAsset<Texture2DContent, Texture2DContent>(map.TilesetTexture, "Texture2DProcessor");
            map.TilesetTexture = context.BuildAndLoadAsset<TextureContent, Texture2DContent>(new ExternalReference<TextureContent>(map.TilesetImageFilename), "TextureProcessor");

            // Determine the number of rows and columns of tiles in the tileset texture            
            int tilesetColumns = map.TilesetTexture.Mipmaps[0].Width / map.TileWidth;
            int tilesetRows = map.TilesetTexture.Mipmaps[0].Height / map.TileWidth;

            // We need to create the bounds for each tile in the tileset image
            // These will be stored in the tiles array
            map.Tiles = new Rectangle[tilesetColumns * tilesetRows];
            context.Logger.LogMessage($"{map.Tiles.Length} Total tiles");
            for (int y = 0; y < tilesetRows; y++)
            {
                for (int x = 0; x < tilesetColumns; x++)
                {
                    map.Tiles[y * tilesetColumns + x] = new Rectangle(
                        x * map.TileWidth,
                        y * map.TileHeight,
                        map.TileWidth,
                        map.TileHeight
                        );
                }
            }


            // Now that we've created our source rectangles, we can 
            // apply the scaling factor to the tile dimensions - this 
            // will have us draw tiles at a different size than their source
            map.TileWidth = (int)(map.TileWidth * Scale);
            map.TileHeight = (int)(map.TileHeight * Scale);

            // Return the fully processed tilemap
            return map;
        }
    }
}