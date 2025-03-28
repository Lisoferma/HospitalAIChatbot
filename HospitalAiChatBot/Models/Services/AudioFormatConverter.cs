﻿using NAudio.Wave;
using NAudio.Vorbis;

namespace HospitalAiChatbot.Models.Services;

/// <summary>
///     Содержит методы для конвертации аудио файлов в другие форматы.
/// </summary>
public static class AudioFormatConverter
{
    /// <summary>
    ///     Конвертирует OGG Stream в WAV byte[] с указанной частотой дискретизации, 16-bit, mono.
    /// </summary>
    /// <param name="oggStream">Входной поток OGG (должен быть читаемым)</param>
    /// <param name="sampleRate">Частота дискретизации выходного WAV аудио.</param>
    /// <returns>WAV данные в виде byte[]</returns>
    /// <exception cref="ArgumentException"></exception>
    public static byte[] ConvertOggStreamToWavBytes(
        Stream oggStream,
        int sampleRate = 16000,
        int bits = 16,
        int channels = 1)
    {
        if (oggStream == null || !oggStream.CanRead)
            throw new ArgumentException("Некорректный входной поток");

        using MemoryStream wavStream = new();
        using VorbisWaveReader oggReader = new(oggStream);

        using WaveFormatConversionStream resampler = new(
            new WaveFormat(sampleRate, bits, channels),
            oggReader);

        WaveFileWriter.WriteWavFileToStream(wavStream, resampler);

        return wavStream.ToArray();
    }
}
