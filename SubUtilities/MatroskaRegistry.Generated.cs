/**
* THIS FILE HAS BEEN AUTOMATICALLY GENERATED, ANY ALTERATIONS MADE TO THE CONTENT OF THIS FILE MAY BE OVERRIDDEN AT ANY TIME
* DO NOT RELY ON MANUAL CHANGES
*/

using System;
using System.Collections.Generic;

namespace SubUtilities.Generated;

public interface IMatroskaElement {
    public string? Path { get; }
    public long? Id { get; }
    public string? Type { get; }
    public string? Length { get; }
    public int? MinOccurs { get; }
    public int? MaxOccurs { get; }
}

public class MatroskaElementRegistry {

    // register known elements
    private static readonly IDictionary<long, IMatroskaElement> _elements = new Dictionary<long, IMatroskaElement> {
        { 0x42F2, new MatroskaEBMLMaxIDLength() },
        { 0x42F3, new MatroskaEBMLMaxSizeLength() },
        { 0x18538067, new MatroskaSegment() },
        { 0x114D9B74, new MatroskaSeekHead() },
        { 0x4DBB, new MatroskaSeek() },
        { 0x53AB, new MatroskaSeekID() },
        { 0x53AC, new MatroskaSeekPosition() },
        { 0x1549A966, new MatroskaInfo() },
        { 0x73A4, new MatroskaSegmentUUID() },
        { 0x7384, new MatroskaSegmentFilename() },
        { 0x3CB923, new MatroskaPrevUUID() },
        { 0x3C83AB, new MatroskaPrevFilename() },
        { 0x3EB923, new MatroskaNextUUID() },
        { 0x3E83BB, new MatroskaNextFilename() },
        { 0x4444, new MatroskaSegmentFamily() },
        { 0x6924, new MatroskaChapterTranslate() },
        { 0x69A5, new MatroskaChapterTranslateID() },
        { 0x69BF, new MatroskaChapterTranslateCodec() },
        { 0x69FC, new MatroskaChapterTranslateEditionUID() },
        { 0x2AD7B1, new MatroskaTimestampScale() },
        { 0x4489, new MatroskaDuration() },
        { 0x4461, new MatroskaDateUTC() },
        { 0x7BA9, new MatroskaTitle() },
        { 0x4D80, new MatroskaMuxingApp() },
        { 0x5741, new MatroskaWritingApp() },
        { 0x1F43B675, new MatroskaCluster() },
        { 0xE7, new MatroskaTimestamp() },
        { 0x5854, new MatroskaSilentTracks() },
        { 0x58D7, new MatroskaSilentTrackNumber() },
        { 0xA7, new MatroskaPosition() },
        { 0xAB, new MatroskaPrevSize() },
        { 0xA3, new MatroskaSimpleBlock() },
        { 0xA0, new MatroskaBlockGroup() },
        { 0xA1, new MatroskaBlock() },
        { 0xA2, new MatroskaBlockVirtual() },
        { 0x75A1, new MatroskaBlockAdditions() },
        { 0xA6, new MatroskaBlockMore() },
        { 0xA5, new MatroskaBlockAdditional() },
        { 0xEE, new MatroskaBlockAddID() },
        { 0x9B, new MatroskaBlockDuration() },
        { 0xFA, new MatroskaReferencePriority() },
        { 0xFB, new MatroskaReferenceBlock() },
        { 0xFD, new MatroskaReferenceVirtual() },
        { 0xA4, new MatroskaCodecState() },
        { 0x75A2, new MatroskaDiscardPadding() },
        { 0x8E, new MatroskaSlices() },
        { 0xE8, new MatroskaTimeSlice() },
        { 0xCC, new MatroskaLaceNumber() },
        { 0xCD, new MatroskaFrameNumber() },
        { 0xCB, new MatroskaBlockAdditionID() },
        { 0xCE, new MatroskaDelay() },
        { 0xCF, new MatroskaSliceDuration() },
        { 0xC8, new MatroskaReferenceFrame() },
        { 0xC9, new MatroskaReferenceOffset() },
        { 0xCA, new MatroskaReferenceTimestamp() },
        { 0xAF, new MatroskaEncryptedBlock() },
        { 0x1654AE6B, new MatroskaTracks() },
        { 0xAE, new MatroskaTrackEntry() },
        { 0xD7, new MatroskaTrackNumber() },
        { 0x73C5, new MatroskaTrackUID() },
        { 0x83, new MatroskaTrackType() },
        { 0xB9, new MatroskaFlagEnabled() },
        { 0x88, new MatroskaFlagDefault() },
        { 0x55AA, new MatroskaFlagForced() },
        { 0x55AB, new MatroskaFlagHearingImpaired() },
        { 0x55AC, new MatroskaFlagVisualImpaired() },
        { 0x55AD, new MatroskaFlagTextDescriptions() },
        { 0x55AE, new MatroskaFlagOriginal() },
        { 0x55AF, new MatroskaFlagCommentary() },
        { 0x9C, new MatroskaFlagLacing() },
        { 0x6DE7, new MatroskaMinCache() },
        { 0x6DF8, new MatroskaMaxCache() },
        { 0x23E383, new MatroskaDefaultDuration() },
        { 0x234E7A, new MatroskaDefaultDecodedFieldDuration() },
        { 0x23314F, new MatroskaTrackTimestampScale() },
        { 0x537F, new MatroskaTrackOffset() },
        { 0x55EE, new MatroskaMaxBlockAdditionID() },
        { 0x41E4, new MatroskaBlockAdditionMapping() },
        { 0x41F0, new MatroskaBlockAddIDValue() },
        { 0x41A4, new MatroskaBlockAddIDName() },
        { 0x41E7, new MatroskaBlockAddIDType() },
        { 0x41ED, new MatroskaBlockAddIDExtraData() },
        { 0x536E, new MatroskaName() },
        { 0x22B59C, new MatroskaLanguage() },
        { 0x22B59D, new MatroskaLanguageBCP47() },
        { 0x86, new MatroskaCodecID() },
        { 0x63A2, new MatroskaCodecPrivate() },
        { 0x258688, new MatroskaCodecName() },
        { 0x7446, new MatroskaAttachmentLink() },
        { 0x3A9697, new MatroskaCodecSettings() },
        { 0x3B4040, new MatroskaCodecInfoURL() },
        { 0x26B240, new MatroskaCodecDownloadURL() },
        { 0xAA, new MatroskaCodecDecodeAll() },
        { 0x6FAB, new MatroskaTrackOverlay() },
        { 0x56AA, new MatroskaCodecDelay() },
        { 0x56BB, new MatroskaSeekPreRoll() },
        { 0x6624, new MatroskaTrackTranslate() },
        { 0x66A5, new MatroskaTrackTranslateTrackID() },
        { 0x66BF, new MatroskaTrackTranslateCodec() },
        { 0x66FC, new MatroskaTrackTranslateEditionUID() },
        { 0xE0, new MatroskaVideo() },
        { 0x9A, new MatroskaFlagInterlaced() },
        { 0x9D, new MatroskaFieldOrder() },
        { 0x53B8, new MatroskaStereoMode() },
        { 0x53C0, new MatroskaAlphaMode() },
        { 0x53B9, new MatroskaOldStereoMode() },
        { 0xB0, new MatroskaPixelWidth() },
        { 0xBA, new MatroskaPixelHeight() },
        { 0x54AA, new MatroskaPixelCropBottom() },
        { 0x54BB, new MatroskaPixelCropTop() },
        { 0x54CC, new MatroskaPixelCropLeft() },
        { 0x54DD, new MatroskaPixelCropRight() },
        { 0x54B0, new MatroskaDisplayWidth() },
        { 0x54BA, new MatroskaDisplayHeight() },
        { 0x54B2, new MatroskaDisplayUnit() },
        { 0x54B3, new MatroskaAspectRatioType() },
        { 0x2EB524, new MatroskaUncompressedFourCC() },
        { 0x2FB523, new MatroskaGammaValue() },
        { 0x2383E3, new MatroskaFrameRate() },
        { 0x55B0, new MatroskaColour() },
        { 0x55B1, new MatroskaMatrixCoefficients() },
        { 0x55B2, new MatroskaBitsPerChannel() },
        { 0x55B3, new MatroskaChromaSubsamplingHorz() },
        { 0x55B4, new MatroskaChromaSubsamplingVert() },
        { 0x55B5, new MatroskaCbSubsamplingHorz() },
        { 0x55B6, new MatroskaCbSubsamplingVert() },
        { 0x55B7, new MatroskaChromaSitingHorz() },
        { 0x55B8, new MatroskaChromaSitingVert() },
        { 0x55B9, new MatroskaRange() },
        { 0x55BA, new MatroskaTransferCharacteristics() },
        { 0x55BB, new MatroskaPrimaries() },
        { 0x55BC, new MatroskaMaxCLL() },
        { 0x55BD, new MatroskaMaxFALL() },
        { 0x55D0, new MatroskaMasteringMetadata() },
        { 0x55D1, new MatroskaPrimaryRChromaticityX() },
        { 0x55D2, new MatroskaPrimaryRChromaticityY() },
        { 0x55D3, new MatroskaPrimaryGChromaticityX() },
        { 0x55D4, new MatroskaPrimaryGChromaticityY() },
        { 0x55D5, new MatroskaPrimaryBChromaticityX() },
        { 0x55D6, new MatroskaPrimaryBChromaticityY() },
        { 0x55D7, new MatroskaWhitePointChromaticityX() },
        { 0x55D8, new MatroskaWhitePointChromaticityY() },
        { 0x55D9, new MatroskaLuminanceMax() },
        { 0x55DA, new MatroskaLuminanceMin() },
        { 0x7670, new MatroskaProjection() },
        { 0x7671, new MatroskaProjectionType() },
        { 0x7672, new MatroskaProjectionPrivate() },
        { 0x7673, new MatroskaProjectionPoseYaw() },
        { 0x7674, new MatroskaProjectionPosePitch() },
        { 0x7675, new MatroskaProjectionPoseRoll() },
        { 0xE1, new MatroskaAudio() },
        { 0xB5, new MatroskaSamplingFrequency() },
        { 0x78B5, new MatroskaOutputSamplingFrequency() },
        { 0x9F, new MatroskaChannels() },
        { 0x7D7B, new MatroskaChannelPositions() },
        { 0x6264, new MatroskaBitDepth() },
        { 0x52F1, new MatroskaEmphasis() },
        { 0xE2, new MatroskaTrackOperation() },
        { 0xE3, new MatroskaTrackCombinePlanes() },
        { 0xE4, new MatroskaTrackPlane() },
        { 0xE5, new MatroskaTrackPlaneUID() },
        { 0xE6, new MatroskaTrackPlaneType() },
        { 0xE9, new MatroskaTrackJoinBlocks() },
        { 0xED, new MatroskaTrackJoinUID() },
        { 0xC0, new MatroskaTrickTrackUID() },
        { 0xC1, new MatroskaTrickTrackSegmentUID() },
        { 0xC6, new MatroskaTrickTrackFlag() },
        { 0xC7, new MatroskaTrickMasterTrackUID() },
        { 0xC4, new MatroskaTrickMasterTrackSegmentUID() },
        { 0x6D80, new MatroskaContentEncodings() },
        { 0x6240, new MatroskaContentEncoding() },
        { 0x5031, new MatroskaContentEncodingOrder() },
        { 0x5032, new MatroskaContentEncodingScope() },
        { 0x5033, new MatroskaContentEncodingType() },
        { 0x5034, new MatroskaContentCompression() },
        { 0x4254, new MatroskaContentCompAlgo() },
        { 0x4255, new MatroskaContentCompSettings() },
        { 0x5035, new MatroskaContentEncryption() },
        { 0x47E1, new MatroskaContentEncAlgo() },
        { 0x47E2, new MatroskaContentEncKeyID() },
        { 0x47E7, new MatroskaContentEncAESSettings() },
        { 0x47E8, new MatroskaAESSettingsCipherMode() },
        { 0x47E3, new MatroskaContentSignature() },
        { 0x47E4, new MatroskaContentSigKeyID() },
        { 0x47E5, new MatroskaContentSigAlgo() },
        { 0x47E6, new MatroskaContentSigHashAlgo() },
        { 0x1C53BB6B, new MatroskaCues() },
        { 0xBB, new MatroskaCuePoint() },
        { 0xB3, new MatroskaCueTime() },
        { 0xB7, new MatroskaCueTrackPositions() },
        { 0xF7, new MatroskaCueTrack() },
        { 0xF1, new MatroskaCueClusterPosition() },
        { 0xF0, new MatroskaCueRelativePosition() },
        { 0xB2, new MatroskaCueDuration() },
        { 0x5378, new MatroskaCueBlockNumber() },
        { 0xEA, new MatroskaCueCodecState() },
        { 0xDB, new MatroskaCueReference() },
        { 0x96, new MatroskaCueRefTime() },
        { 0x97, new MatroskaCueRefCluster() },
        { 0x535F, new MatroskaCueRefNumber() },
        { 0xEB, new MatroskaCueRefCodecState() },
        { 0x1941A469, new MatroskaAttachments() },
        { 0x61A7, new MatroskaAttachedFile() },
        { 0x467E, new MatroskaFileDescription() },
        { 0x466E, new MatroskaFileName() },
        { 0x4660, new MatroskaFileMediaType() },
        { 0x465C, new MatroskaFileData() },
        { 0x46AE, new MatroskaFileUID() },
        { 0x4675, new MatroskaFileReferral() },
        { 0x4661, new MatroskaFileUsedStartTime() },
        { 0x4662, new MatroskaFileUsedEndTime() },
        { 0x1043A770, new MatroskaChapters() },
        { 0x45B9, new MatroskaEditionEntry() },
        { 0x45BC, new MatroskaEditionUID() },
        { 0x45BD, new MatroskaEditionFlagHidden() },
        { 0x45DB, new MatroskaEditionFlagDefault() },
        { 0x45DD, new MatroskaEditionFlagOrdered() },
        { 0x4520, new MatroskaEditionDisplay() },
        { 0x4521, new MatroskaEditionString() },
        { 0x45E4, new MatroskaEditionLanguageIETF() },
        { 0xB6, new MatroskaChapterAtom() },
        { 0x73C4, new MatroskaChapterUID() },
        { 0x5654, new MatroskaChapterStringUID() },
        { 0x91, new MatroskaChapterTimeStart() },
        { 0x92, new MatroskaChapterTimeEnd() },
        { 0x98, new MatroskaChapterFlagHidden() },
        { 0x4598, new MatroskaChapterFlagEnabled() },
        { 0x6E67, new MatroskaChapterSegmentUUID() },
        { 0x4588, new MatroskaChapterSkipType() },
        { 0x6EBC, new MatroskaChapterSegmentEditionUID() },
        { 0x63C3, new MatroskaChapterPhysicalEquiv() },
        { 0x8F, new MatroskaChapterTrack() },
        { 0x89, new MatroskaChapterTrackUID() },
        { 0x80, new MatroskaChapterDisplay() },
        { 0x85, new MatroskaChapString() },
        { 0x437C, new MatroskaChapLanguage() },
        { 0x437D, new MatroskaChapLanguageBCP47() },
        { 0x437E, new MatroskaChapCountry() },
        { 0x6944, new MatroskaChapProcess() },
        { 0x6955, new MatroskaChapProcessCodecID() },
        { 0x450D, new MatroskaChapProcessPrivate() },
        { 0x6911, new MatroskaChapProcessCommand() },
        { 0x6922, new MatroskaChapProcessTime() },
        { 0x6933, new MatroskaChapProcessData() },
        { 0x1254C367, new MatroskaTags() },
        { 0x7373, new MatroskaTag() },
        { 0x63C0, new MatroskaTargets() },
        { 0x68CA, new MatroskaTargetTypeValue() },
        { 0x63CA, new MatroskaTargetType() },
        { 0x63C5, new MatroskaTagTrackUID() },
        { 0x63C9, new MatroskaTagEditionUID() },
        { 0x63C4, new MatroskaTagChapterUID() },
        { 0x63C6, new MatroskaTagAttachmentUID() },
        { 0x67C8, new MatroskaSimpleTag() },
        { 0x45A3, new MatroskaTagName() },
        { 0x447A, new MatroskaTagLanguage() },
        { 0x447B, new MatroskaTagLanguageBCP47() },
        { 0x4484, new MatroskaTagDefault() },
        { 0x44B4, new MatroskaTagDefaultBogus() },
        { 0x4487, new MatroskaTagString() },
        { 0x4485, new MatroskaTagBinary() }
    };

    public static IMatroskaElement? FindElement(long id) => _elements.TryGetValue(id, out var element) ? element : null;

}

public class MatroskaEBMLMaxIDLength : IMatroskaElement {
    public string? Path => @"\EBML\EBMLMaxIDLength";
    public long? Id => 0x42F2;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

public class MatroskaEBMLMaxSizeLength : IMatroskaElement {
    public string? Path => @"\EBML\EBMLMaxSizeLength";
    public long? Id => 0x42F3;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSegment : IMatroskaElement {
    public string? Path => @"\Segment";
    public long? Id => 0x18538067;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains seeking information of Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSeekHead : IMatroskaElement {
    public string? Path => @"\Segment\SeekHead";
    public long? Id => 0x114D9B74;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 2;
}

/// <summary>
/// Contains a single seek entry to an EBML Element.
/// </summary>
public class MatroskaSeek : IMatroskaElement {
    public string? Path => @"\Segment\SeekHead\Seek";
    public long? Id => 0x4DBB;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The binary EBML ID of a Top-Level Element.
/// </summary>
public class MatroskaSeekID : IMatroskaElement {
    public string? Path => @"\Segment\SeekHead\Seek\SeekID";
    public long? Id => 0x53AB;
    public string? Type => @"binary";
    public string? Length => @"<= 4";
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Segment Position ((#segment-position)) of a Top-Level Element.
/// </summary>
public class MatroskaSeekPosition : IMatroskaElement {
    public string? Path => @"\Segment\SeekHead\Seek\SeekPosition";
    public long? Id => 0x53AC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains general information about the Segment.
/// </summary>
public class MatroskaInfo : IMatroskaElement {
    public string? Path => @"\Segment\Info";
    public long? Id => 0x1549A966;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A randomly generated unique ID to identify the Segment amongst many others (128 bits). It is equivalent to a UUID v4 [@!RFC4122] with all bits randomly (or pseudo-randomly) chosen.  An actual UUID v4 value, where some bits are not random, **MAY** also be used.
/// </summary>
public class MatroskaSegmentUUID : IMatroskaElement {
    public string? Path => @"\Segment\Info\SegmentUUID";
    public long? Id => 0x73A4;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A filename corresponding to this Segment.
/// </summary>
public class MatroskaSegmentFilename : IMatroskaElement {
    public string? Path => @"\Segment\Info\SegmentFilename";
    public long? Id => 0x7384;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// An ID to identify the previous Segment of a Linked Segment.
/// </summary>
public class MatroskaPrevUUID : IMatroskaElement {
    public string? Path => @"\Segment\Info\PrevUUID";
    public long? Id => 0x3CB923;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A filename corresponding to the file of the previous Linked Segment.
/// </summary>
public class MatroskaPrevFilename : IMatroskaElement {
    public string? Path => @"\Segment\Info\PrevFilename";
    public long? Id => 0x3C83AB;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// An ID to identify the next Segment of a Linked Segment.
/// </summary>
public class MatroskaNextUUID : IMatroskaElement {
    public string? Path => @"\Segment\Info\NextUUID";
    public long? Id => 0x3EB923;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A filename corresponding to the file of the next Linked Segment.
/// </summary>
public class MatroskaNextFilename : IMatroskaElement {
    public string? Path => @"\Segment\Info\NextFilename";
    public long? Id => 0x3E83BB;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A unique ID that all Segments of a Linked Segment **MUST** share (128 bits). It is equivalent to a UUID v4 [@!RFC4122] with all bits randomly (or pseudo-randomly) chosen. An actual UUID v4 value, where some bits are not random, **MAY** also be used.
/// </summary>
public class MatroskaSegmentFamily : IMatroskaElement {
    public string? Path => @"\Segment\Info\SegmentFamily";
    public long? Id => 0x4444;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The mapping between this `Segment` and a segment value in the given Chapter Codec.
/// </summary>
public class MatroskaChapterTranslate : IMatroskaElement {
    public string? Path => @"\Segment\Info\ChapterTranslate";
    public long? Id => 0x6924;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The binary value used to represent this Segment in the chapter codec data.
/// The format depends on the ChapProcessCodecID used; see (#chapprocesscodecid-element).
/// </summary>
public class MatroskaChapterTranslateID : IMatroskaElement {
    public string? Path => @"\Segment\Info\ChapterTranslate\ChapterTranslateID";
    public long? Id => 0x69A5;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// This `ChapterTranslate` applies to this chapter codec of the given chapter edition(s); see (#chapprocesscodecid-element).
/// </summary>
public class MatroskaChapterTranslateCodec : IMatroskaElement {
    public string? Path => @"\Segment\Info\ChapterTranslate\ChapterTranslateCodec";
    public long? Id => 0x69BF;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specify a chapter edition UID on which this `ChapterTranslate` applies.
/// </summary>
public class MatroskaChapterTranslateEditionUID : IMatroskaElement {
    public string? Path => @"\Segment\Info\ChapterTranslate\ChapterTranslateEditionUID";
    public long? Id => 0x69FC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Base unit for Segment Ticks and Track Ticks, in nanoseconds. A TimestampScale value of 1000000 means scaled timestamps in the Segment are expressed in milliseconds; see (#timestamps) on how to interpret timestamps.
/// </summary>
public class MatroskaTimestampScale : IMatroskaElement {
    public string? Path => @"\Segment\Info\TimestampScale";
    public long? Id => 0x2AD7B1;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Duration of the Segment, expressed in Segment Ticks which is based on TimestampScale; see (#timestamp-ticks).
/// </summary>
public class MatroskaDuration : IMatroskaElement {
    public string? Path => @"\Segment\Info\Duration";
    public long? Id => 0x4489;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The date and time that the Segment was created by the muxing application or library.
/// </summary>
public class MatroskaDateUTC : IMatroskaElement {
    public string? Path => @"\Segment\Info\DateUTC";
    public long? Id => 0x4461;
    public string? Type => @"date";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// General name of the Segment.
/// </summary>
public class MatroskaTitle : IMatroskaElement {
    public string? Path => @"\Segment\Info\Title";
    public long? Id => 0x7BA9;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Muxing application or library (example: "libmatroska-0.4.3").
/// </summary>
public class MatroskaMuxingApp : IMatroskaElement {
    public string? Path => @"\Segment\Info\MuxingApp";
    public long? Id => 0x4D80;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Writing application (example: "mkvmerge-0.3.3").
/// </summary>
public class MatroskaWritingApp : IMatroskaElement {
    public string? Path => @"\Segment\Info\WritingApp";
    public long? Id => 0x5741;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Top-Level Element containing the (monolithic) Block structure.
/// </summary>
public class MatroskaCluster : IMatroskaElement {
    public string? Path => @"\Segment\Cluster";
    public long? Id => 0x1F43B675;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Absolute timestamp of the cluster, expressed in Segment Ticks which is based on TimestampScale; see (#timestamp-ticks).
/// </summary>
public class MatroskaTimestamp : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\Timestamp";
    public long? Id => 0xE7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The list of tracks that are not used in that part of the stream.
/// It is useful when using overlay tracks on seeking or to decide what track to use.
/// </summary>
public class MatroskaSilentTracks : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\SilentTracks";
    public long? Id => 0x5854;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// One of the track number that are not used from now on in the stream.
/// It could change later if not specified as silent in a further Cluster.
/// </summary>
public class MatroskaSilentTrackNumber : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\SilentTracks\SilentTrackNumber";
    public long? Id => 0x58D7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Segment Position of the Cluster in the Segment (0 in live streams).
/// It might help to resynchronise offset on damaged streams.
/// </summary>
public class MatroskaPosition : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\Position";
    public long? Id => 0xA7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Size of the previous Cluster, in octets. Can be useful for backward playing.
/// </summary>
public class MatroskaPrevSize : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\PrevSize";
    public long? Id => 0xAB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Similar to Block, see (#block-structure), but without all the extra information,
/// mostly used to reduced overhead when no extra feature is needed; see (#simpleblock-structure) on SimpleBlock Structure.
/// </summary>
public class MatroskaSimpleBlock : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\SimpleBlock";
    public long? Id => 0xA3;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Basic container of information containing a single Block and information specific to that Block.
/// </summary>
public class MatroskaBlockGroup : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup";
    public long? Id => 0xA0;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Block containing the actual data to be rendered and a timestamp relative to the Cluster Timestamp;
/// see (#block-structure) on Block Structure.
/// </summary>
public class MatroskaBlock : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\Block";
    public long? Id => 0xA1;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A Block with no data. It **MUST** be stored in the stream at the place the real Block would be in display order.
/// </summary>
public class MatroskaBlockVirtual : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockVirtual";
    public long? Id => 0xA2;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contain additional binary data to complete the main one; see Codec BlockAdditions section of [@?MatroskaCodec] for more information.
/// An EBML parser that has no knowledge of the Block structure could still see and use/skip these data.
/// </summary>
public class MatroskaBlockAdditions : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockAdditions";
    public long? Id => 0x75A1;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contain the BlockAdditional and some parameters.
/// </summary>
public class MatroskaBlockMore : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockAdditions\BlockMore";
    public long? Id => 0xA6;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// Interpreted by the codec as it wishes (using the BlockAddID).
/// </summary>
public class MatroskaBlockAdditional : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockAdditions\BlockMore\BlockAdditional";
    public long? Id => 0xA5;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// An ID to identify how to interpret the BlockAdditional data; see Codec BlockAdditions section of [@?MatroskaCodec] for more information.
/// A value of 1 indicates that the meaning of the BlockAdditional data is defined by the codec.
/// Any other value indicates the meaning of the BlockAdditional data is found in the BlockAddIDType found in the TrackEntry.
/// </summary>
public class MatroskaBlockAddID : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockAdditions\BlockMore\BlockAddID";
    public long? Id => 0xEE;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The duration of the Block, expressed in Track Ticks; see (#timestamp-ticks).
/// The BlockDuration Element can be useful at the end of a Track to define the duration of the last frame (as there is no subsequent Block available),
/// or when there is a break in a track like for subtitle tracks.
/// </summary>
public class MatroskaBlockDuration : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockDuration";
    public long? Id => 0x9B;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// This frame is referenced and has the specified cache priority.
/// In cache only a frame of the same or higher priority can replace this frame. A value of 0 means the frame is not referenced.
/// </summary>
public class MatroskaReferencePriority : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferencePriority";
    public long? Id => 0xFA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A timestamp value, relative to the timestamp of the Block in this BlockGroup, expressed in Track Ticks; see (#timestamp-ticks).
/// This is used to reference other frames necessary to decode this frame.
/// The relative value **SHOULD** correspond to a valid `Block` this `Block` depends on.
/// Historically Matroska Writer didn't write the actual `Block(s)` this `Block` depends on, but *some* `Block` in the past.
/// The value "0" **MAY** also be used to signify this `Block` cannot be decoded on its own, but without knownledge of which `Block` is necessary. In this case, other `ReferenceBlock` **MUST NOT** be found in the same `BlockGroup`.
/// If the `BlockGroup` doesn't have any `ReferenceBlock` element, then the `Block` it contains can be decoded without using any other `Block` data.
/// </summary>
public class MatroskaReferenceBlock : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferenceBlock";
    public long? Id => 0xFB;
    public string? Type => @"integer";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Segment Position of the data that would otherwise be in position of the virtual block.
/// </summary>
public class MatroskaReferenceVirtual : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferenceVirtual";
    public long? Id => 0xFD;
    public string? Type => @"integer";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The new codec state to use. Data interpretation is private to the codec.
/// This information **SHOULD** always be referenced by a seek entry.
/// </summary>
public class MatroskaCodecState : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\CodecState";
    public long? Id => 0xA4;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Duration of the silent data added to the Block, expressed in Matroska Ticks -- i.e., in nanoseconds; see (#timestamp-ticks)
/// (padding at the end of the Block for positive value, at the beginning of the Block for negative value).
/// The duration of DiscardPadding is not calculated in the duration of the TrackEntry and **SHOULD** be discarded during playback.
/// </summary>
public class MatroskaDiscardPadding : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\DiscardPadding";
    public long? Id => 0x75A2;
    public string? Type => @"integer";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains slices description.
/// </summary>
public class MatroskaSlices : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices";
    public long? Id => 0x8E;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains extra time information about the data contained in the Block.
/// Being able to interpret this Element is not **REQUIRED** for playback.
/// </summary>
public class MatroskaTimeSlice : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice";
    public long? Id => 0xE8;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The reverse number of the frame in the lace (0 is the last frame, 1 is the next to last, etc.).
/// Being able to interpret this Element is not **REQUIRED** for playback.
/// </summary>
public class MatroskaLaceNumber : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice\LaceNumber";
    public long? Id => 0xCC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The number of the frame to generate from this lace with this delay
/// (allow you to generate many frames from the same Block/Frame).
/// </summary>
public class MatroskaFrameNumber : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice\FrameNumber";
    public long? Id => 0xCD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The ID of the BlockAdditional Element (0 is the main Block).
/// </summary>
public class MatroskaBlockAdditionID : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice\BlockAdditionID";
    public long? Id => 0xCB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The delay to apply to the Element, expressed in Track Ticks; see (#timestamp-ticks).
/// </summary>
public class MatroskaDelay : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice\Delay";
    public long? Id => 0xCE;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The duration to apply to the Element, expressed in Track Ticks; see (#timestamp-ticks).
/// </summary>
public class MatroskaSliceDuration : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice\SliceDuration";
    public long? Id => 0xCF;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains information about the last reference frame. See [@?DivXTrickTrack].
/// </summary>
public class MatroskaReferenceFrame : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferenceFrame";
    public long? Id => 0xC8;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The relative offset, in bytes, from the previous BlockGroup element for this Smooth FF/RW video track to the containing BlockGroup element. See [@?DivXTrickTrack].
/// </summary>
public class MatroskaReferenceOffset : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferenceFrame\ReferenceOffset";
    public long? Id => 0xC9;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The timestamp of the BlockGroup pointed to by ReferenceOffset, expressed in Track Ticks; see (#timestamp-ticks). See [@?DivXTrickTrack].
/// </summary>
public class MatroskaReferenceTimestamp : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferenceFrame\ReferenceTimestamp";
    public long? Id => 0xCA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Similar to SimpleBlock, see (#simpleblock-structure),
/// but the data inside the Block are Transformed (encrypt and/or signed).
/// </summary>
public class MatroskaEncryptedBlock : IMatroskaElement {
    public string? Path => @"\Segment\Cluster\EncryptedBlock";
    public long? Id => 0xAF;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// A Top-Level Element of information with many tracks described.
/// </summary>
public class MatroskaTracks : IMatroskaElement {
    public string? Path => @"\Segment\Tracks";
    public long? Id => 0x1654AE6B;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Describes a track with all Elements.
/// </summary>
public class MatroskaTrackEntry : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry";
    public long? Id => 0xAE;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The track number as used in the Block Header.
/// </summary>
public class MatroskaTrackNumber : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackNumber";
    public long? Id => 0xD7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A unique ID to identify the Track.
/// </summary>
public class MatroskaTrackUID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackUID";
    public long? Id => 0x73C5;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The `TrackType` defines the type of each frame found in the Track.
/// The value **SHOULD** be stored on 1 octet.
/// </summary>
public class MatroskaTrackType : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackType";
    public long? Id => 0x83;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if the track is usable. It is possible to turn a not usable track into a usable track using chapter codecs or control tracks.
/// </summary>
public class MatroskaFlagEnabled : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagEnabled";
    public long? Id => 0xB9;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set if that track (audio, video or subs) is eligible for automatic selection by the player; see (#default-track-selection) for more details.
/// </summary>
public class MatroskaFlagDefault : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagDefault";
    public long? Id => 0x88;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Applies only to subtitles. Set if that track is eligible for automatic selection by the player if it matches the user's language preference,
/// even if the user's preferences would normally not enable subtitles with the selected audio track;
/// this can be used for tracks containing only translations of foreign-language audio or onscreen text.
/// See (#default-track-selection) for more details.
/// </summary>
public class MatroskaFlagForced : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagForced";
    public long? Id => 0x55AA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if and only if that track is suitable for users with hearing impairments.
/// </summary>
public class MatroskaFlagHearingImpaired : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagHearingImpaired";
    public long? Id => 0x55AB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if and only if that track is suitable for users with visual impairments.
/// </summary>
public class MatroskaFlagVisualImpaired : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagVisualImpaired";
    public long? Id => 0x55AC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if and only if that track contains textual descriptions of video content.
/// </summary>
public class MatroskaFlagTextDescriptions : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagTextDescriptions";
    public long? Id => 0x55AD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if and only if that track is in the content's original language.
/// </summary>
public class MatroskaFlagOriginal : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagOriginal";
    public long? Id => 0x55AE;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if and only if that track contains commentary.
/// </summary>
public class MatroskaFlagCommentary : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagCommentary";
    public long? Id => 0x55AF;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if the track **MAY** contain blocks using lacing. When set to 0 all blocks **MUST** have their lacing flags set to No lacing; see (#block-lacing) on Block Lacing.
/// </summary>
public class MatroskaFlagLacing : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagLacing";
    public long? Id => 0x9C;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The minimum number of frames a player **SHOULD** be able to cache during playback.
/// If set to 0, the reference pseudo-cache system is not used.
/// </summary>
public class MatroskaMinCache : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\MinCache";
    public long? Id => 0x6DE7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The maximum cache size necessary to store referenced frames in and the current frame.
/// 0 means no cache is needed.
/// </summary>
public class MatroskaMaxCache : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\MaxCache";
    public long? Id => 0x6DF8;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Number of nanoseconds per frame, expressed in Matroska Ticks -- i.e., in nanoseconds; see (#timestamp-ticks)
/// (frame in the Matroska sense -- one Element put into a (Simple)Block).
/// </summary>
public class MatroskaDefaultDuration : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\DefaultDuration";
    public long? Id => 0x23E383;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The period between two successive fields at the output of the decoding process, expressed in Matroska Ticks -- i.e., in nanoseconds; see (#timestamp-ticks).
/// see (#defaultdecodedfieldduration) for more information
/// </summary>
public class MatroskaDefaultDecodedFieldDuration : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\DefaultDecodedFieldDuration";
    public long? Id => 0x234E7A;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The scale to apply on this track to work at normal speed in relation with other tracks
/// (mostly used to adjust video speed when the audio length differs).
/// </summary>
public class MatroskaTrackTimestampScale : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackTimestampScale";
    public long? Id => 0x23314F;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A value to add to the Block's Timestamp, expressed in Matroska Ticks -- i.e., in nanoseconds; see (#timestamp-ticks).
/// This can be used to adjust the playback offset of a track.
/// </summary>
public class MatroskaTrackOffset : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOffset";
    public long? Id => 0x537F;
    public string? Type => @"integer";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The maximum value of BlockAddID ((#blockaddid-element)).
/// A value 0 means there is no BlockAdditions ((#blockadditions-element)) for this track.
/// </summary>
public class MatroskaMaxBlockAdditionID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\MaxBlockAdditionID";
    public long? Id => 0x55EE;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains elements that extend the track format, by adding content either to each frame,
/// with BlockAddID ((#blockaddid-element)), or to the track as a whole
/// with BlockAddIDExtraData.
/// </summary>
public class MatroskaBlockAdditionMapping : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\BlockAdditionMapping";
    public long? Id => 0x41E4;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// If the track format extension needs content beside frames,
/// the value refers to the BlockAddID ((#blockaddid-element)), value being described.
/// </summary>
public class MatroskaBlockAddIDValue : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\BlockAdditionMapping\BlockAddIDValue";
    public long? Id => 0x41F0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A human-friendly name describing the type of BlockAdditional data,
/// as defined by the associated Block Additional Mapping.
/// </summary>
public class MatroskaBlockAddIDName : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\BlockAdditionMapping\BlockAddIDName";
    public long? Id => 0x41A4;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Stores the registered identifier of the Block Additional Mapping
/// to define how the BlockAdditional data should be handled.
/// </summary>
public class MatroskaBlockAddIDType : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\BlockAdditionMapping\BlockAddIDType";
    public long? Id => 0x41E7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Extra binary data that the BlockAddIDType can use to interpret the BlockAdditional data.
/// The interpretation of the binary data depends on the BlockAddIDType value and the corresponding Block Additional Mapping.
/// </summary>
public class MatroskaBlockAddIDExtraData : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\BlockAdditionMapping\BlockAddIDExtraData";
    public long? Id => 0x41ED;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A human-readable track name.
/// </summary>
public class MatroskaName : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Name";
    public long? Id => 0x536E;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The language of the track,
/// in the Matroska languages form; see (#language-codes) on language codes.
/// This Element **MUST** be ignored if the LanguageBCP47 Element is used in the same TrackEntry.
/// </summary>
public class MatroskaLanguage : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Language";
    public long? Id => 0x22B59C;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The language of the track,
/// in the [@!BCP47] form; see (#language-codes) on language codes.
/// If this Element is used, then any Language Elements used in the same TrackEntry **MUST** be ignored.
/// </summary>
public class MatroskaLanguageBCP47 : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\LanguageBCP47";
    public long? Id => 0x22B59D;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// An ID corresponding to the codec,
/// see [@?MatroskaCodec] for more info.
/// </summary>
public class MatroskaCodecID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecID";
    public long? Id => 0x86;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Private data only known to the codec.
/// </summary>
public class MatroskaCodecPrivate : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecPrivate";
    public long? Id => 0x63A2;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A human-readable string specifying the codec.
/// </summary>
public class MatroskaCodecName : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecName";
    public long? Id => 0x258688;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The UID of an attachment that is used by this codec.
/// </summary>
public class MatroskaAttachmentLink : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\AttachmentLink";
    public long? Id => 0x7446;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A string describing the encoding setting used.
/// </summary>
public class MatroskaCodecSettings : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecSettings";
    public long? Id => 0x3A9697;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A URL to find information about the codec used.
/// </summary>
public class MatroskaCodecInfoURL : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecInfoURL";
    public long? Id => 0x3B4040;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// A URL to download about the codec used.
/// </summary>
public class MatroskaCodecDownloadURL : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecDownloadURL";
    public long? Id => 0x26B240;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Set to 1 if the codec can decode potentially damaged data.
/// </summary>
public class MatroskaCodecDecodeAll : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecDecodeAll";
    public long? Id => 0xAA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specify that this track is an overlay track for the Track specified (in the u-integer).
/// That means when this track has a gap, see (#silenttracks-element) on SilentTracks,
/// the overlay track **SHOULD** be used instead. The order of multiple TrackOverlay matters, the first one is the one that **SHOULD** be used.
/// If not found it **SHOULD** be the second, etc.
/// </summary>
public class MatroskaTrackOverlay : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOverlay";
    public long? Id => 0x6FAB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// CodecDelay is The codec-built-in delay, expressed in Matroska Ticks -- i.e., in nanoseconds; see (#timestamp-ticks).
/// It represents the amount of codec samples that will be discarded by the decoder during playback.
/// This timestamp value **MUST** be subtracted from each frame timestamp in order to get the timestamp that will be actually played.
/// The value **SHOULD** be small so the muxing of tracks with the same actual timestamp are in the same Cluster.
/// </summary>
public class MatroskaCodecDelay : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecDelay";
    public long? Id => 0x56AA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// After a discontinuity, SeekPreRoll is the duration of the data
/// the decoder **MUST** decode before the decoded data is valid, expressed in Matroska Ticks -- i.e., in nanoseconds; see (#timestamp-ticks).
/// </summary>
public class MatroskaSeekPreRoll : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\SeekPreRoll";
    public long? Id => 0x56BB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The mapping between this `TrackEntry` and a track value in the given Chapter Codec.
/// </summary>
public class MatroskaTrackTranslate : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackTranslate";
    public long? Id => 0x6624;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The binary value used to represent this `TrackEntry` in the chapter codec data.
/// The format depends on the `ChapProcessCodecID` used; see (#chapprocesscodecid-element).
/// </summary>
public class MatroskaTrackTranslateTrackID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackTranslate\TrackTranslateTrackID";
    public long? Id => 0x66A5;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// This `TrackTranslate` applies to this chapter codec of the given chapter edition(s); see (#chapprocesscodecid-element).
/// </summary>
public class MatroskaTrackTranslateCodec : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackTranslate\TrackTranslateCodec";
    public long? Id => 0x66BF;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specify a chapter edition UID on which this `TrackTranslate` applies.
/// </summary>
public class MatroskaTrackTranslateEditionUID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackTranslate\TrackTranslateEditionUID";
    public long? Id => 0x66FC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Video settings.
/// </summary>
public class MatroskaVideo : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video";
    public long? Id => 0xE0;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specify whether the video frames in this track are interlaced.
/// </summary>
public class MatroskaFlagInterlaced : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\FlagInterlaced";
    public long? Id => 0x9A;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specify the field ordering of video frames in this track.
/// </summary>
public class MatroskaFieldOrder : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\FieldOrder";
    public long? Id => 0x9D;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Stereo-3D video mode. There are some more details in (#multi-planar-and-3d-videos).
/// </summary>
public class MatroskaStereoMode : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\StereoMode";
    public long? Id => 0x53B8;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Indicate whether the BlockAdditional Element with BlockAddID of "1" contains Alpha data, as defined by to the Codec Mapping for the `CodecID`.
/// Undefined values **SHOULD NOT** be used as the behavior of known implementations is different (considered either as 0 or 1).
/// </summary>
public class MatroskaAlphaMode : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\AlphaMode";
    public long? Id => 0x53C0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Bogus StereoMode value used in old versions of libmatroska.
/// </summary>
public class MatroskaOldStereoMode : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\OldStereoMode";
    public long? Id => 0x53B9;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Width of the encoded video frames in pixels.
/// </summary>
public class MatroskaPixelWidth : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelWidth";
    public long? Id => 0xB0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Height of the encoded video frames in pixels.
/// </summary>
public class MatroskaPixelHeight : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelHeight";
    public long? Id => 0xBA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The number of video pixels to remove at the bottom of the image.
/// </summary>
public class MatroskaPixelCropBottom : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelCropBottom";
    public long? Id => 0x54AA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The number of video pixels to remove at the top of the image.
/// </summary>
public class MatroskaPixelCropTop : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelCropTop";
    public long? Id => 0x54BB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The number of video pixels to remove on the left of the image.
/// </summary>
public class MatroskaPixelCropLeft : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelCropLeft";
    public long? Id => 0x54CC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The number of video pixels to remove on the right of the image.
/// </summary>
public class MatroskaPixelCropRight : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelCropRight";
    public long? Id => 0x54DD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Width of the video frames to display. Applies to the video frame after cropping (PixelCrop* Elements).
/// </summary>
public class MatroskaDisplayWidth : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\DisplayWidth";
    public long? Id => 0x54B0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Height of the video frames to display. Applies to the video frame after cropping (PixelCrop* Elements).
/// </summary>
public class MatroskaDisplayHeight : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\DisplayHeight";
    public long? Id => 0x54BA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// How DisplayWidth & DisplayHeight are interpreted.
/// </summary>
public class MatroskaDisplayUnit : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\DisplayUnit";
    public long? Id => 0x54B2;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specify the possible modifications to the aspect ratio.
/// </summary>
public class MatroskaAspectRatioType : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\AspectRatioType";
    public long? Id => 0x54B3;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specify the uncompressed pixel format used for the Track's data as a FourCC.
/// This value is similar in scope to the biCompression value of AVI's `BITMAPINFO` [@?AVIFormat]. There is no definitive list of FourCC values, nor an official registry. Some common values for YUV pixel formats can be found at [@?MSYUV8], [@?MSYUV16] and [@?FourCC-YUV]. Some common values for uncompressed RGB pixel formats can be found at [@?MSRGB] and [@?FourCC-RGB].
/// </summary>
public class MatroskaUncompressedFourCC : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\UncompressedFourCC";
    public long? Id => 0x2EB524;
    public string? Type => @"binary";
    public string? Length => @"4";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Gamma Value.
/// </summary>
public class MatroskaGammaValue : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\GammaValue";
    public long? Id => 0x2FB523;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Number of frames per second. This value is Informational only. It is intended for constant frame rate streams, and **SHOULD NOT** be used for a variable frame rate TrackEntry.
/// </summary>
public class MatroskaFrameRate : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\FrameRate";
    public long? Id => 0x2383E3;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Settings describing the colour format.
/// </summary>
public class MatroskaColour : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour";
    public long? Id => 0x55B0;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Matrix Coefficients of the video used to derive luma and chroma values from red, green, and blue color primaries.
/// For clarity, the value and meanings for MatrixCoefficients are adopted from Table 4 of ISO/IEC 23001-8:2016 or ITU-T H.273.
/// </summary>
public class MatroskaMatrixCoefficients : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MatrixCoefficients";
    public long? Id => 0x55B1;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Number of decoded bits per channel. A value of 0 indicates that the BitsPerChannel is unspecified.
/// </summary>
public class MatroskaBitsPerChannel : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\BitsPerChannel";
    public long? Id => 0x55B2;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The amount of pixels to remove in the Cr and Cb channels for every pixel not removed horizontally.
/// Example: For video with 4:2:0 chroma subsampling, the ChromaSubsamplingHorz **SHOULD** be set to 1.
/// </summary>
public class MatroskaChromaSubsamplingHorz : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\ChromaSubsamplingHorz";
    public long? Id => 0x55B3;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The amount of pixels to remove in the Cr and Cb channels for every pixel not removed vertically.
/// Example: For video with 4:2:0 chroma subsampling, the ChromaSubsamplingVert **SHOULD** be set to 1.
/// </summary>
public class MatroskaChromaSubsamplingVert : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\ChromaSubsamplingVert";
    public long? Id => 0x55B4;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The amount of pixels to remove in the Cb channel for every pixel not removed horizontally.
/// This is additive with ChromaSubsamplingHorz. Example: For video with 4:2:1 chroma subsampling,
/// the ChromaSubsamplingHorz **SHOULD** be set to 1 and CbSubsamplingHorz **SHOULD** be set to 1.
/// </summary>
public class MatroskaCbSubsamplingHorz : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\CbSubsamplingHorz";
    public long? Id => 0x55B5;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The amount of pixels to remove in the Cb channel for every pixel not removed vertically.
/// This is additive with ChromaSubsamplingVert.
/// </summary>
public class MatroskaCbSubsamplingVert : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\CbSubsamplingVert";
    public long? Id => 0x55B6;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// How chroma is subsampled horizontally.
/// </summary>
public class MatroskaChromaSitingHorz : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\ChromaSitingHorz";
    public long? Id => 0x55B7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// How chroma is subsampled vertically.
/// </summary>
public class MatroskaChromaSitingVert : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\ChromaSitingVert";
    public long? Id => 0x55B8;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Clipping of the color ranges.
/// </summary>
public class MatroskaRange : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\Range";
    public long? Id => 0x55B9;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The transfer characteristics of the video. For clarity,
/// the value and meanings for TransferCharacteristics are adopted from Table 3 of ISO/IEC 23091-4 or ITU-T H.273.
/// </summary>
public class MatroskaTransferCharacteristics : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\TransferCharacteristics";
    public long? Id => 0x55BA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The colour primaries of the video. For clarity,
/// the value and meanings for Primaries are adopted from Table 2 of ISO/IEC 23091-4 or ITU-T H.273.
/// </summary>
public class MatroskaPrimaries : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\Primaries";
    public long? Id => 0x55BB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Maximum brightness of a single pixel (Maximum Content Light Level)
/// in candelas per square meter (cd/m^2^).
/// </summary>
public class MatroskaMaxCLL : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MaxCLL";
    public long? Id => 0x55BC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Maximum brightness of a single full frame (Maximum Frame-Average Light Level)
/// in candelas per square meter (cd/m^2^).
/// </summary>
public class MatroskaMaxFALL : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MaxFALL";
    public long? Id => 0x55BD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// SMPTE 2086 mastering data.
/// </summary>
public class MatroskaMasteringMetadata : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata";
    public long? Id => 0x55D0;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Red X chromaticity coordinate, as defined by [@!CIE-1931].
/// </summary>
public class MatroskaPrimaryRChromaticityX : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryRChromaticityX";
    public long? Id => 0x55D1;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Red Y chromaticity coordinate, as defined by [@!CIE-1931].
/// </summary>
public class MatroskaPrimaryRChromaticityY : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryRChromaticityY";
    public long? Id => 0x55D2;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Green X chromaticity coordinate, as defined by [@!CIE-1931].
/// </summary>
public class MatroskaPrimaryGChromaticityX : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryGChromaticityX";
    public long? Id => 0x55D3;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Green Y chromaticity coordinate, as defined by [@!CIE-1931].
/// </summary>
public class MatroskaPrimaryGChromaticityY : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryGChromaticityY";
    public long? Id => 0x55D4;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Blue X chromaticity coordinate, as defined by [@!CIE-1931].
/// </summary>
public class MatroskaPrimaryBChromaticityX : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryBChromaticityX";
    public long? Id => 0x55D5;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Blue Y chromaticity coordinate, as defined by [@!CIE-1931].
/// </summary>
public class MatroskaPrimaryBChromaticityY : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryBChromaticityY";
    public long? Id => 0x55D6;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// White X chromaticity coordinate, as defined by [@!CIE-1931].
/// </summary>
public class MatroskaWhitePointChromaticityX : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\WhitePointChromaticityX";
    public long? Id => 0x55D7;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// White Y chromaticity coordinate, as defined by [@!CIE-1931].
/// </summary>
public class MatroskaWhitePointChromaticityY : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\WhitePointChromaticityY";
    public long? Id => 0x55D8;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Maximum luminance. Represented in candelas per square meter (cd/m^2^).
/// </summary>
public class MatroskaLuminanceMax : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\LuminanceMax";
    public long? Id => 0x55D9;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Minimum luminance. Represented in candelas per square meter (cd/m^2^).
/// </summary>
public class MatroskaLuminanceMin : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\LuminanceMin";
    public long? Id => 0x55DA;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Describes the video projection details. Used to render spherical, VR videos or flipping videos horizontally/vertically.
/// </summary>
public class MatroskaProjection : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection";
    public long? Id => 0x7670;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Describes the projection used for this video track.
/// </summary>
public class MatroskaProjectionType : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection\ProjectionType";
    public long? Id => 0x7671;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Private data that only applies to a specific projection.
/// *  If `ProjectionType` equals 0 (Rectangular),
/// then this element **MUST NOT** be present.
/// *  If `ProjectionType` equals 1 (Equirectangular), then this element **MUST** be present and contain the same binary data that would be stored inside
/// an ISOBMFF Equirectangular Projection Box ('equi').
/// *  If `ProjectionType` equals 2 (Cubemap), then this element **MUST** be present and contain the same binary data that would be stored
/// inside an ISOBMFF Cubemap Projection Box ('cbmp').
/// *  If `ProjectionType` equals 3 (Mesh), then this element **MUST** be present and contain the same binary data that would be stored inside
/// an ISOBMFF Mesh Projection Box ('mshp').
/// </summary>
public class MatroskaProjectionPrivate : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection\ProjectionPrivate";
    public long? Id => 0x7672;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specifies a yaw rotation to the projection.
/// Value represents a clockwise rotation, in degrees, around the up vector. This rotation must be applied
/// before any `ProjectionPosePitch` or `ProjectionPoseRoll` rotations.
/// The value of this element **MUST** be in the -180 to 180 degree range, both included.
/// Setting `ProjectionPoseYaw` to 180 or -180 degrees, with the `ProjectionPoseRoll` and `ProjectionPosePitch` set to 0 degrees flips the image horizontally.
/// </summary>
public class MatroskaProjectionPoseYaw : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection\ProjectionPoseYaw";
    public long? Id => 0x7673;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specifies a pitch rotation to the projection.
/// Value represents a counter-clockwise rotation, in degrees, around the right vector. This rotation must be applied
/// after the `ProjectionPoseYaw` rotation and before the `ProjectionPoseRoll` rotation.
/// The value of this element **MUST** be in the -90 to 90 degree range, both included.
/// </summary>
public class MatroskaProjectionPosePitch : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection\ProjectionPosePitch";
    public long? Id => 0x7674;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specifies a roll rotation to the projection.
/// Value represents a counter-clockwise rotation, in degrees, around the forward vector. This rotation must be applied
/// after the `ProjectionPoseYaw` and `ProjectionPosePitch` rotations.
/// The value of this element **MUST** be in the -180 to 180 degree range, both included.
/// Setting `ProjectionPoseRoll` to 180 or -180 degrees, the `ProjectionPoseYaw` to 180 or -180 degrees with `ProjectionPosePitch` set to 0 degrees flips the image vertically.
/// Setting `ProjectionPoseRoll` to 180 or -180 degrees, with the `ProjectionPoseYaw` and `ProjectionPosePitch` set to 0 degrees flips the image horizontally and vertically.
/// </summary>
public class MatroskaProjectionPoseRoll : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection\ProjectionPoseRoll";
    public long? Id => 0x7675;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Audio settings.
/// </summary>
public class MatroskaAudio : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio";
    public long? Id => 0xE1;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Sampling frequency in Hz.
/// </summary>
public class MatroskaSamplingFrequency : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\SamplingFrequency";
    public long? Id => 0xB5;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Real output sampling frequency in Hz (used for SBR techniques).
/// </summary>
public class MatroskaOutputSamplingFrequency : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\OutputSamplingFrequency";
    public long? Id => 0x78B5;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Numbers of channels in the track.
/// </summary>
public class MatroskaChannels : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\Channels";
    public long? Id => 0x9F;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Table of horizontal angles for each successive channel.
/// </summary>
public class MatroskaChannelPositions : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\ChannelPositions";
    public long? Id => 0x7D7B;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Bits per sample, mostly used for PCM.
/// </summary>
public class MatroskaBitDepth : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\BitDepth";
    public long? Id => 0x6264;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Audio emphasis applied on audio samples. The player **MUST** apply the inverse emphasis to get the proper audio samples.
/// </summary>
public class MatroskaEmphasis : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\Emphasis";
    public long? Id => 0x52F1;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Operation that needs to be applied on tracks to create this virtual track.
/// For more details look at (#track-operation).
/// </summary>
public class MatroskaTrackOperation : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation";
    public long? Id => 0xE2;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains the list of all video plane tracks that need to be combined to create this 3D track
/// </summary>
public class MatroskaTrackCombinePlanes : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackCombinePlanes";
    public long? Id => 0xE3;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains a video plane track that need to be combined to create this 3D track
/// </summary>
public class MatroskaTrackPlane : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackCombinePlanes\TrackPlane";
    public long? Id => 0xE4;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The trackUID number of the track representing the plane.
/// </summary>
public class MatroskaTrackPlaneUID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackCombinePlanes\TrackPlane\TrackPlaneUID";
    public long? Id => 0xE5;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The kind of plane this track corresponds to.
/// </summary>
public class MatroskaTrackPlaneType : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackCombinePlanes\TrackPlane\TrackPlaneType";
    public long? Id => 0xE6;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains the list of all tracks whose Blocks need to be combined to create this virtual track
/// </summary>
public class MatroskaTrackJoinBlocks : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackJoinBlocks";
    public long? Id => 0xE9;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The trackUID number of a track whose blocks are used to create this virtual track.
/// </summary>
public class MatroskaTrackJoinUID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackJoinBlocks\TrackJoinUID";
    public long? Id => 0xED;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The TrackUID of the Smooth FF/RW video in the paired EBML structure corresponding to this video track. See [@?DivXTrickTrack].
/// </summary>
public class MatroskaTrickTrackUID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrickTrackUID";
    public long? Id => 0xC0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The SegmentUID of the Segment containing the track identified by TrickTrackUID. See [@?DivXTrickTrack].
/// </summary>
public class MatroskaTrickTrackSegmentUID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrickTrackSegmentUID";
    public long? Id => 0xC1;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if this video track is a Smooth FF/RW track. If set to 1, MasterTrackUID and MasterTrackSegUID should must be present and BlockGroups for this track must contain ReferenceFrame structures.
/// Otherwise, TrickTrackUID and TrickTrackSegUID must be present if this track has a corresponding Smooth FF/RW track. See [@?DivXTrickTrack].
/// </summary>
public class MatroskaTrickTrackFlag : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrickTrackFlag";
    public long? Id => 0xC6;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The TrackUID of the video track in the paired EBML structure that corresponds to this Smooth FF/RW track. See [@?DivXTrickTrack].
/// </summary>
public class MatroskaTrickMasterTrackUID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrickMasterTrackUID";
    public long? Id => 0xC7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The SegmentUID of the Segment containing the track identified by MasterTrackUID. See [@?DivXTrickTrack].
/// </summary>
public class MatroskaTrickMasterTrackSegmentUID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrickMasterTrackSegmentUID";
    public long? Id => 0xC4;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Settings for several content encoding mechanisms like compression or encryption.
/// </summary>
public class MatroskaContentEncodings : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings";
    public long? Id => 0x6D80;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Settings for one content encoding like compression or encryption.
/// </summary>
public class MatroskaContentEncoding : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding";
    public long? Id => 0x6240;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// Tell in which order to apply each `ContentEncoding` of the `ContentEncodings`.
/// The decoder/demuxer **MUST** start with the `ContentEncoding` with the highest `ContentEncodingOrder` and work its way down to the `ContentEncoding` with the lowest `ContentEncodingOrder`.
/// This value **MUST** be unique over for each `ContentEncoding` found in the `ContentEncodings` of this `TrackEntry`.
/// </summary>
public class MatroskaContentEncodingOrder : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncodingOrder";
    public long? Id => 0x5031;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A bit field that describes which Elements have been modified in this way.
/// Values (big-endian) can be OR'ed.
/// </summary>
public class MatroskaContentEncodingScope : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncodingScope";
    public long? Id => 0x5032;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A value describing what kind of transformation is applied.
/// </summary>
public class MatroskaContentEncodingType : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncodingType";
    public long? Id => 0x5033;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Settings describing the compression used.
/// This Element **MUST** be present if the value of ContentEncodingType is 0 and absent otherwise.
/// Each block **MUST** be decompressable even if no previous block is available in order not to prevent seeking.
/// </summary>
public class MatroskaContentCompression : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentCompression";
    public long? Id => 0x5034;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The compression algorithm used.
/// </summary>
public class MatroskaContentCompAlgo : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentCompression\ContentCompAlgo";
    public long? Id => 0x4254;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Settings that might be needed by the decompressor. For Header Stripping (`ContentCompAlgo`=3),
/// the bytes that were removed from the beginning of each frames of the track.
/// </summary>
public class MatroskaContentCompSettings : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentCompression\ContentCompSettings";
    public long? Id => 0x4255;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Settings describing the encryption used.
/// This Element **MUST** be present if the value of `ContentEncodingType` is 1 (encryption) and **MUST** be ignored otherwise.
/// A Matroska Player **MAY** support encryption.
/// </summary>
public class MatroskaContentEncryption : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption";
    public long? Id => 0x5035;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The encryption algorithm used.
/// </summary>
public class MatroskaContentEncAlgo : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentEncAlgo";
    public long? Id => 0x47E1;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// For public key algorithms this is the ID of the public key the the data was encrypted with.
/// </summary>
public class MatroskaContentEncKeyID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentEncKeyID";
    public long? Id => 0x47E2;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Settings describing the encryption algorithm used.
/// </summary>
public class MatroskaContentEncAESSettings : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentEncAESSettings";
    public long? Id => 0x47E7;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The AES cipher mode used in the encryption.
/// </summary>
public class MatroskaAESSettingsCipherMode : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentEncAESSettings\AESSettingsCipherMode";
    public long? Id => 0x47E8;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A cryptographic signature of the contents.
/// </summary>
public class MatroskaContentSignature : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentSignature";
    public long? Id => 0x47E3;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// This is the ID of the private key the data was signed with.
/// </summary>
public class MatroskaContentSigKeyID : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentSigKeyID";
    public long? Id => 0x47E4;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The algorithm used for the signature.
/// </summary>
public class MatroskaContentSigAlgo : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentSigAlgo";
    public long? Id => 0x47E5;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The hash algorithm used for the signature.
/// </summary>
public class MatroskaContentSigHashAlgo : IMatroskaElement {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentSigHashAlgo";
    public long? Id => 0x47E6;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A Top-Level Element to speed seeking access.
/// All entries are local to the Segment.
/// </summary>
public class MatroskaCues : IMatroskaElement {
    public string? Path => @"\Segment\Cues";
    public long? Id => 0x1C53BB6B;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains all information relative to a seek point in the Segment.
/// </summary>
public class MatroskaCuePoint : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint";
    public long? Id => 0xBB;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// Absolute timestamp of the seek point, expressed in Matroska Ticks -- i.e., in nanoseconds; see (#timestamp-ticks).
/// </summary>
public class MatroskaCueTime : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTime";
    public long? Id => 0xB3;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contain positions for different tracks corresponding to the timestamp.
/// </summary>
public class MatroskaCueTrackPositions : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions";
    public long? Id => 0xB7;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The track for which a position is given.
/// </summary>
public class MatroskaCueTrack : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueTrack";
    public long? Id => 0xF7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Segment Position ((#segment-position)) of the Cluster containing the associated Block.
/// </summary>
public class MatroskaCueClusterPosition : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueClusterPosition";
    public long? Id => 0xF1;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The relative position inside the Cluster of the referenced SimpleBlock or BlockGroup
/// with 0 being the first possible position for an Element inside that Cluster.
/// </summary>
public class MatroskaCueRelativePosition : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueRelativePosition";
    public long? Id => 0xF0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The duration of the block, expressed in Segment Ticks which is based on TimestampScale; see (#timestamp-ticks).
/// If missing, the track's DefaultDuration does not apply and no duration information is available in terms of the cues.
/// </summary>
public class MatroskaCueDuration : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueDuration";
    public long? Id => 0xB2;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Number of the Block in the specified Cluster.
/// </summary>
public class MatroskaCueBlockNumber : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueBlockNumber";
    public long? Id => 0x5378;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Segment Position ((#segment-position)) of the Codec State corresponding to this Cue Element.
/// 0 means that the data is taken from the initial Track Entry.
/// </summary>
public class MatroskaCueCodecState : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueCodecState";
    public long? Id => 0xEA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Clusters containing the referenced Blocks.
/// </summary>
public class MatroskaCueReference : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueReference";
    public long? Id => 0xDB;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Timestamp of the referenced Block, expressed in Matroska Ticks -- i.e., in nanoseconds; see (#timestamp-ticks).
/// </summary>
public class MatroskaCueRefTime : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueReference\CueRefTime";
    public long? Id => 0x96;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Segment Position of the Cluster containing the referenced Block.
/// </summary>
public class MatroskaCueRefCluster : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueReference\CueRefCluster";
    public long? Id => 0x97;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Number of the referenced Block of Track X in the specified Cluster.
/// </summary>
public class MatroskaCueRefNumber : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueReference\CueRefNumber";
    public long? Id => 0x535F;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Segment Position of the Codec State corresponding to this referenced Element.
/// 0 means that the data is taken from the initial Track Entry.
/// </summary>
public class MatroskaCueRefCodecState : IMatroskaElement {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueReference\CueRefCodecState";
    public long? Id => 0xEB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contain attached files.
/// </summary>
public class MatroskaAttachments : IMatroskaElement {
    public string? Path => @"\Segment\Attachments";
    public long? Id => 0x1941A469;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// An attached file.
/// </summary>
public class MatroskaAttachedFile : IMatroskaElement {
    public string? Path => @"\Segment\Attachments\AttachedFile";
    public long? Id => 0x61A7;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// A human-friendly name for the attached file.
/// </summary>
public class MatroskaFileDescription : IMatroskaElement {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileDescription";
    public long? Id => 0x467E;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Filename of the attached file.
/// </summary>
public class MatroskaFileName : IMatroskaElement {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileName";
    public long? Id => 0x466E;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Media type of the file following the [@!RFC6838] format.
/// </summary>
public class MatroskaFileMediaType : IMatroskaElement {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileMediaType";
    public long? Id => 0x4660;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The data of the file.
/// </summary>
public class MatroskaFileData : IMatroskaElement {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileData";
    public long? Id => 0x465C;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Unique ID representing the file, as random as possible.
/// </summary>
public class MatroskaFileUID : IMatroskaElement {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileUID";
    public long? Id => 0x46AE;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A binary value that a track/codec can refer to when the attachment is needed.
/// </summary>
public class MatroskaFileReferral : IMatroskaElement {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileReferral";
    public long? Id => 0x4675;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The timestamp at which this optimized font attachment comes into context, expressed in Segment Ticks which is based on TimestampScale. See [@?DivXWorldFonts].
/// </summary>
public class MatroskaFileUsedStartTime : IMatroskaElement {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileUsedStartTime";
    public long? Id => 0x4661;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The timestamp at which this optimized font attachment goes out of context, expressed in Segment Ticks which is based on TimestampScale. See [@?DivXWorldFonts].
/// </summary>
public class MatroskaFileUsedEndTime : IMatroskaElement {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileUsedEndTime";
    public long? Id => 0x4662;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A system to define basic menus and partition data.
/// For more detailed information, look at the Chapters explanation in (#chapters).
/// </summary>
public class MatroskaChapters : IMatroskaElement {
    public string? Path => @"\Segment\Chapters";
    public long? Id => 0x1043A770;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains all information about a Segment edition.
/// </summary>
public class MatroskaEditionEntry : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry";
    public long? Id => 0x45B9;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// A unique ID to identify the edition. It's useful for tagging an edition.
/// </summary>
public class MatroskaEditionUID : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionUID";
    public long? Id => 0x45BC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if an edition is hidden. Hidden editions **SHOULD NOT** be available to the user interface
/// (but still to Control Tracks; see (#chapter-flags) on Chapter flags).
/// </summary>
public class MatroskaEditionFlagHidden : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionFlagHidden";
    public long? Id => 0x45BD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if the edition **SHOULD** be used as the default one.
/// </summary>
public class MatroskaEditionFlagDefault : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionFlagDefault";
    public long? Id => 0x45DB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if the chapters can be defined multiple times and the order to play them is enforced; see (#editionflagordered).
/// </summary>
public class MatroskaEditionFlagOrdered : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionFlagOrdered";
    public long? Id => 0x45DD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains a possible string to use for the edition display for the given languages.
/// </summary>
public class MatroskaEditionDisplay : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionDisplay";
    public long? Id => 0x4520;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Contains the string to use as the edition name.
/// </summary>
public class MatroskaEditionString : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionDisplay\EditionString";
    public long? Id => 0x4521;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// One language corresponding to the EditionString,
/// in the [@!BCP47] form; see (#language-codes) on language codes.
/// </summary>
public class MatroskaEditionLanguageIETF : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionDisplay\EditionLanguageIETF";
    public long? Id => 0x45E4;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Contains the atom information to use as the chapter atom (apply to all tracks).
/// </summary>
public class MatroskaChapterAtom : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom";
    public long? Id => 0xB6;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// A unique ID to identify the Chapter.
/// </summary>
public class MatroskaChapterUID : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterUID";
    public long? Id => 0x73C4;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A unique string ID to identify the Chapter.
/// For example it is used as the storage for [@?WebVTT] cue identifier values.
/// </summary>
public class MatroskaChapterStringUID : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterStringUID";
    public long? Id => 0x5654;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Timestamp of the start of Chapter, expressed in Matroska Ticks -- i.e., in nanoseconds; see (#timestamp-ticks).
/// </summary>
public class MatroskaChapterTimeStart : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterTimeStart";
    public long? Id => 0x91;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Timestamp of the end of Chapter timestamp excluded, expressed in Matroska Ticks -- i.e., in nanoseconds; see (#timestamp-ticks).
/// The value **MUST** be greater than or equal to the `ChapterTimeStart` of the same `ChapterAtom`.
/// </summary>
public class MatroskaChapterTimeEnd : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterTimeEnd";
    public long? Id => 0x92;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if a chapter is hidden. Hidden chapters **SHOULD NOT** be available to the user interface
/// (but still to Control Tracks; see (#chapterflaghidden) on Chapter flags).
/// </summary>
public class MatroskaChapterFlagHidden : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterFlagHidden";
    public long? Id => 0x98;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Set to 1 if the chapter is enabled. It can be enabled/disabled by a Control Track.
/// When disabled, the movie **SHOULD** skip all the content between the TimeStart and TimeEnd of this chapter; see (#chapter-flags) on Chapter flags.
/// </summary>
public class MatroskaChapterFlagEnabled : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterFlagEnabled";
    public long? Id => 0x4598;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The SegmentUUID of another Segment to play during this chapter.
/// </summary>
public class MatroskaChapterSegmentUUID : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterSegmentUUID";
    public long? Id => 0x6E67;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Indicate what type of content the ChapterAtom contains and might be skipped. It can be used to automatically skip content based on the type.
/// If a `ChapterAtom` is inside a `ChapterAtom` that has a `ChapterSkipType` set, it **MUST NOT** have a `ChapterSkipType` or have a `ChapterSkipType` with the same value as it's parent `ChapterAtom`.
/// If the `ChapterAtom` doesn't contain a `ChapterTimeEnd`, the value of the `ChapterSkipType` is only valid until the next `ChapterAtom` with a `ChapterSkipType` value or the end of the file.
/// </summary>
public class MatroskaChapterSkipType : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterSkipType";
    public long? Id => 0x4588;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The EditionUID to play from the Segment linked in ChapterSegmentUUID.
/// If ChapterSegmentEditionUID is undeclared, then no Edition of the linked Segment is used; see (#medium-linking) on medium-linking Segments.
/// </summary>
public class MatroskaChapterSegmentEditionUID : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterSegmentEditionUID";
    public long? Id => 0x6EBC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specify the physical equivalent of this ChapterAtom like "DVD" (60) or "SIDE" (50);
/// see (#physical-types) for a complete list of values.
/// </summary>
public class MatroskaChapterPhysicalEquiv : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterPhysicalEquiv";
    public long? Id => 0x63C3;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// List of tracks on which the chapter applies. If this Element is not present, all tracks apply
/// </summary>
public class MatroskaChapterTrack : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterTrack";
    public long? Id => 0x8F;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// UID of the Track to apply this chapter to.
/// In the absence of a control track, choosing this chapter will select the listed Tracks and deselect unlisted tracks.
/// Absence of this Element indicates that the Chapter **SHOULD** be applied to any currently used Tracks.
/// </summary>
public class MatroskaChapterTrackUID : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterTrack\ChapterTrackUID";
    public long? Id => 0x89;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// Contains all possible strings to use for the chapter display.
/// </summary>
public class MatroskaChapterDisplay : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterDisplay";
    public long? Id => 0x80;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Contains the string to use as the chapter atom.
/// </summary>
public class MatroskaChapString : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterDisplay\ChapString";
    public long? Id => 0x85;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A language corresponding to the string,
/// in the Matroska languages form; see (#language-codes) on language codes.
/// This Element **MUST** be ignored if a ChapLanguageBCP47 Element is used within the same ChapterDisplay Element.
/// </summary>
public class MatroskaChapLanguage : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterDisplay\ChapLanguage";
    public long? Id => 0x437C;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// A language corresponding to the ChapString,
/// in the [@!BCP47] form; see (#language-codes) on language codes.
/// If a ChapLanguageBCP47 Element is used, then any ChapLanguage and ChapCountry Elements used in the same ChapterDisplay **MUST** be ignored.
/// </summary>
public class MatroskaChapLanguageBCP47 : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterDisplay\ChapLanguageBCP47";
    public long? Id => 0x437D;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// A country corresponding to the string,
/// in the Matroska countries form; see (#country-codes) on country codes.
/// This Element **MUST** be ignored if a ChapLanguageBCP47 Element is used within the same ChapterDisplay Element.
/// </summary>
public class MatroskaChapCountry : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterDisplay\ChapCountry";
    public long? Id => 0x437E;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Contains all the commands associated to the Atom.
/// </summary>
public class MatroskaChapProcess : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess";
    public long? Id => 0x6944;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Contains the type of the codec used for the processing.
/// A value of 0 means native Matroska processing (to be defined), a value of 1 means the DVD command set is used; see (#menu-features) on DVD menus.
/// More codec IDs can be added later.
/// </summary>
public class MatroskaChapProcessCodecID : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess\ChapProcessCodecID";
    public long? Id => 0x6955;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Some optional data attached to the ChapProcessCodecID information.
/// For ChapProcessCodecID = 1, it is the "DVD level" equivalent; see (#menu-features) on DVD menus.
/// </summary>
public class MatroskaChapProcessPrivate : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess\ChapProcessPrivate";
    public long? Id => 0x450D;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains all the commands associated to the Atom.
/// </summary>
public class MatroskaChapProcessCommand : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess\ChapProcessCommand";
    public long? Id => 0x6911;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Defines when the process command **SHOULD** be handled
/// </summary>
public class MatroskaChapProcessTime : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess\ChapProcessCommand\ChapProcessTime";
    public long? Id => 0x6922;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Contains the command information.
/// The data **SHOULD** be interpreted depending on the ChapProcessCodecID value. For ChapProcessCodecID = 1,
/// the data correspond to the binary DVD cell pre/post commands; see (#menu-features) on DVD menus.
/// </summary>
public class MatroskaChapProcessData : IMatroskaElement {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess\ChapProcessCommand\ChapProcessData";
    public long? Id => 0x6933;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Element containing metadata describing Tracks, Editions, Chapters, Attachments, or the Segment as a whole.
/// A list of valid tags can be found in [@?MatroskaTags].
/// </summary>
public class MatroskaTags : IMatroskaElement {
    public string? Path => @"\Segment\Tags";
    public long? Id => 0x1254C367;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// A single metadata descriptor.
/// </summary>
public class MatroskaTag : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag";
    public long? Id => 0x7373;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// Specifies which other elements the metadata represented by the Tag applies to.
/// If empty or omitted, then the Tag describes everything in the Segment.
/// </summary>
public class MatroskaTargets : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\Targets";
    public long? Id => 0x63C0;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A number to indicate the logical level of the target.
/// </summary>
public class MatroskaTargetTypeValue : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\Targets\TargetTypeValue";
    public long? Id => 0x68CA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// An informational string that can be used to display the logical level of the target like "ALBUM", "TRACK", "MOVIE", "CHAPTER", etc.
/// ; see Section 6.4 of [@?MatroskaTags].
/// </summary>
public class MatroskaTargetType : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\Targets\TargetType";
    public long? Id => 0x63CA;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A unique ID to identify the Track(s) the tags belong to.
/// </summary>
public class MatroskaTagTrackUID : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\Targets\TagTrackUID";
    public long? Id => 0x63C5;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// A unique ID to identify the EditionEntry(s) the tags belong to.
/// </summary>
public class MatroskaTagEditionUID : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\Targets\TagEditionUID";
    public long? Id => 0x63C9;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// A unique ID to identify the Chapter(s) the tags belong to.
/// </summary>
public class MatroskaTagChapterUID : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\Targets\TagChapterUID";
    public long? Id => 0x63C4;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// A unique ID to identify the Attachment(s) the tags belong to.
/// </summary>
public class MatroskaTagAttachmentUID : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\Targets\TagAttachmentUID";
    public long? Id => 0x63C6;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// Contains general information about the target.
/// </summary>
public class MatroskaSimpleTag : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag";
    public long? Id => 0x67C8;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The name of the Tag that is going to be stored.
/// </summary>
public class MatroskaTagName : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagName";
    public long? Id => 0x45A3;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// Specifies the language of the tag specified,
/// in the Matroska languages form; see (#language-codes) on language codes.
/// This Element **MUST** be ignored if the TagLanguageBCP47 Element is used within the same SimpleTag Element.
/// </summary>
public class MatroskaTagLanguage : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagLanguage";
    public long? Id => 0x447A;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The language used in the TagString,
/// in the [@!BCP47] form; see (#language-codes) on language codes.
/// If this Element is used, then any TagLanguage Elements used in the same SimpleTag **MUST** be ignored.
/// </summary>
public class MatroskaTagLanguageBCP47 : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagLanguageBCP47";
    public long? Id => 0x447B;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A boolean value to indicate if this is the default/original language to use for the given tag.
/// </summary>
public class MatroskaTagDefault : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagDefault";
    public long? Id => 0x4484;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// A variant of the TagDefault element with a bogus Element ID; see (#tagdefault-element).
/// </summary>
public class MatroskaTagDefaultBogus : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagDefaultBogus";
    public long? Id => 0x44B4;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The value of the Tag.
/// </summary>
public class MatroskaTagString : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagString";
    public long? Id => 0x4487;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The values of the Tag, if it is binary. Note that this cannot be used in the same SimpleTag as TagString.
/// </summary>
public class MatroskaTagBinary : IMatroskaElement {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagBinary";
    public long? Id => 0x4485;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}
