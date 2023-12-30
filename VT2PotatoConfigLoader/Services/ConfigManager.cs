namespace UmgakConfig.Services
{
    internal class ConfigManager
    {
        // Todo: resolution, sound, visuals ef, override sett low, local_lights = false
        // dx12, fov, fullscreen, priority, equipment, ammo counter, kill confirm, ff marker
        // mute background, num ping

        public static void SetOptimizedSettings()
        {
            FileParser.EditLine(DiskUtils.ConfigPath, false, @"max_fps\s*=\s*\d+", "max_fps = 165");
            FileParser.EditLine(DiskUtils.ConfigPath, false, @"max_stacking_frames\s*=\s*\d+", "max_stacking_frames = 1");
            FileParser.EditLine(DiskUtils.ConfigPath, false, @"eye_adaptation_speed\s*=\s*\d+", "eye_adaptation_speed = 2");
            // EditLine(PATH, false, @"lod_decoration_density\s*=\s*\d+", "lod_decoration_density = 0");

            FileParser.EditLine(DiskUtils.ConfigPath, false, @"use_baked_enemy_meshes\s*=\s*[^;\r\n]*", "use_baked_enemy_meshes = true");
            FileParser.EditLine(DiskUtils.ConfigPath, false, @"particles_cast_shadows\s*=\s*[^;\r\n]*", "particles_cast_shadows = false");

            FileParser.EditLine(DiskUtils.ConfigPath, false, @"particles_distance_culling\s*=\s*[^;\r\n]*", "particles_distance_culling = false");
            FileParser.EditLine(DiskUtils.ConfigPath, false, @"static_sun_shadows\s*=\s*[^;\r\n]*", "static_sun_shadows = false");
            FileParser.EditLine(DiskUtils.ConfigPath, false, @"ui_bloom_enabled\s*=\s*[^;\r\n]*", "ui_bloom_enabled = false");

            FileParser.EditLine(DiskUtils.ConfigPath, false, @"lod_object_multiplier\s*=\s*\d+(\.\d+)?", "lod_object_multiplier = 0.75");

            FileParser.EditLine(DiskUtils.ConfigPath, false, @"cached_local_lights_shadow_atlas_size\s*=\s*\[\s*\d+\s*\d+\s*\]", "cached_local_lights_shadow_atlas_size = [\r\n                128\r\n                128\r\n        ]");
            FileParser.EditLine(DiskUtils.ConfigPath, false, @"local_lights_shadow_atlas_size\s*=\s*\[\s*\d+\s*\d+\s*\]", "local_lights_shadow_atlas_size = [\r\n                128\r\n                128\r\n        ]");
            FileParser.EditLine(DiskUtils.ConfigPath, false, @"mixed_resolution_rendering_size\s*=\s*\[\s*\d+\s*\d+\s*\]", "mixed_resolution_rendering_size = [\r\n                320\r\n                200\r\n        ]");
            FileParser.EditLine(DiskUtils.ConfigPath, false, @"world_interaction_size\s*=\s*\[\s*\d+\s*\d+\s*\]", "world_interaction_size = [\r\n                320\r\n                200\r\n        ]");
            FileParser.EditLine(DiskUtils.ConfigPath, false, @"volumetric_data_size\s*=\s*\[\s*\d+\s*\d+\s*\d+\s*\]", "volumetric_data_size = [\r\n                8\r\n                4\r\n                12\r\n        ]");

            SetEnvironmentTextures();

            Console.WriteLine("Optimized settings applied.");
        }

        static void SetCharacterTextures()
        {
            FileParser.EditString("texture_categories/character_df", "100");
            FileParser.EditString("texture_categories/character_df_1p", "100");
            FileParser.EditString("texture_categories/character_dfa", "100");
            FileParser.EditString("texture_categories/character_ma", "100");
            FileParser.EditString("texture_categories/character_ma_1p", "100");
            FileParser.EditString("texture_categories/character_nm", "100");
            FileParser.EditString("texture_categories/character_nm_1p", "100");
        }

        static void SetEnvironmentTextures()
        {
            FileParser.EditString("texture_categories/environment_df", "100");
            FileParser.EditString("texture_categories/environment_dfa", "100");
            FileParser.EditString("texture_categories/environment_dfa1", "100");
            FileParser.EditString("texture_categories/environment_gsm", "100");
            FileParser.EditString("texture_categories/environment_hm", "100");
            FileParser.EditString("texture_categories/environment_hma", "100");
            FileParser.EditString("texture_categories/environment_nm", "100");
            FileParser.EditString("texture_categories/environment_streamable_df", "100");
            FileParser.EditString("texture_categories/environment_streamable_dfa", "100");
            FileParser.EditString("texture_categories/environment_streamable_ma", "100");
            FileParser.EditString("texture_categories/environment_streamable_nm", "100");
        }

        static void SetWeaponTextures()
        {
            FileParser.EditString("texture_categories/weapon_df", "100");
            FileParser.EditString("texture_categories/weapon_df_3p", "100");
            FileParser.EditString("texture_categories/weapon_dfa", "100");
            FileParser.EditString("texture_categories/weapon_ma", "100");
            FileParser.EditString("texture_categories/weapon_ma_3p", "100");
            FileParser.EditString("texture_categories/weapon_mae", "100");
            FileParser.EditString("texture_categories/weapon_nm", "100");
            FileParser.EditString("texture_categories/weapon_nm_3p", "100");
        }
    }
}
