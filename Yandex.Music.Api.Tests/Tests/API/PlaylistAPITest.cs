﻿using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Common.YPlaylist;
using Yandex.Music.Api.Common.YTrack;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(5)]
    [TestBeforeAfter]
    public class PlaylistAPITest : YandexTest
    {
        #region Поля

        // Яндекс
        private static string userId = "139954184";

        // Лучшие песни русского рока
        private static string kinds = "2050";
        private static string title = "Лучшие песни русского рока";

        // Arven - Black Is the Colour - All I Got
        private static string trackId = "14318563";
        private static string albumId = "4256391";

        #endregion Поля

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Playlist = Fixture.API.PlaylistAPI.Get(Fixture.Storage, userId, kinds);
            Fixture.Playlist.Title.Should().Be(title);
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(1)]
        public void MainPagePersonal_ValidData_True()
        {
            List<YPlaylist> mainPage = Fixture.API.PlaylistAPI.MainPagePersonal(Fixture.Storage);

            Output.WriteLine(mainPage.Count.ToString());

            mainPage.Should().NotBeNull();
            mainPage.Count.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(2)]
        public void OfTheDay_ValidData_True()
        {
            YPlaylist response = Fixture.API.PlaylistAPI.OfTheDay(Fixture.Storage);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(3)]
        public void Premiere_ValidData_True()
        {
            YPlaylist response = Fixture.API.PlaylistAPI.Premiere(Fixture.Storage);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(4)]
        public void DejaVu_ValidData_True()
        {
            YPlaylist response = Fixture.API.PlaylistAPI.DejaVu(Fixture.Storage);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(5)]
        public void Missed_ValidData_True()
        {
            YPlaylist response = Fixture.API.PlaylistAPI.Missed(Fixture.Storage);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(6)]
        public void Alice_ValidData_True()
        {
            YPlaylist response = Fixture.API.PlaylistAPI.Alice(Fixture.Storage);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(7)]
        public void Podcasts_ValidData_True()
        {
            YPlaylist response = Fixture.API.PlaylistAPI.Podcasts(Fixture.Storage);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(8)]
        public void Create_ValidData_True()
        {
            Fixture.CreatedPlaylist = Fixture.API.PlaylistAPI.Create(Fixture.Storage, "Test Playlist");

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(9)]
        public void InsertTrack_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();
            Fixture.Track.Should().NotBeNull();

            Fixture.CreatedPlaylist = Fixture.API.PlaylistAPI.InsertTracks(Fixture.Storage, Fixture.CreatedPlaylist, new List<YTrack> {
                Fixture.Track
            });

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(10)]
        public void DeleteTrack_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();
            Fixture.Track.Should().NotBeNull();

            Fixture.CreatedPlaylist = Fixture.API.PlaylistAPI.DeleteTrack(Fixture.Storage, Fixture.CreatedPlaylist, new List<YTrack> {
                Fixture.Track
            });

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(11)]
        public void Rename_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();

            Fixture.CreatedPlaylist = Fixture.API.PlaylistAPI.Rename(Fixture.Storage, Fixture.CreatedPlaylist, "New Playlist");

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(12)]
        public void Remove_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();

            bool response = Fixture.API.PlaylistAPI.Delete(Fixture.Storage, Fixture.CreatedPlaylist);

            response.Should().BeTrue();
        }

        public PlaylistAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}