/**
* THIS FILE HAS BEEN AUTOMATICALLY GENERATED, ANY ALTERATIONS MADE TO THE CONTENT OF THIS FILE MAY BE OVERRIDDEN AT ANY TIME
* DO NOT RELY ON MANUAL CHANGES
*/

using System;

namespace SubUtilities.Generated;

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEBMLMaxIDLength {
    public string? Path => @"\EBML\EBMLMaxIDLength";
    public long? Id => 0x42F2;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEBMLMaxSizeLength {
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
public class MatroskaSegment {
    public string? Path => @"\Segment";
    public long? Id => 0x18538067;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSeekHead {
    public string? Path => @"\Segment\SeekHead";
    public long? Id => 0x114D9B74;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 2;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSeek {
    public string? Path => @"\Segment\SeekHead\Seek";
    public long? Id => 0x4DBB;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSeekID {
    public string? Path => @"\Segment\SeekHead\Seek\SeekID";
    public long? Id => 0x53AB;
    public string? Type => @"binary";
    public string? Length => @"<= 4";
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSeekPosition {
    public string? Path => @"\Segment\SeekHead\Seek\SeekPosition";
    public long? Id => 0x53AC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaInfo {
    public string? Path => @"\Segment\Info";
    public long? Id => 0x1549A966;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSegmentUUID {
    public string? Path => @"\Segment\Info\SegmentUUID";
    public long? Id => 0x73A4;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSegmentFilename {
    public string? Path => @"\Segment\Info\SegmentFilename";
    public long? Id => 0x7384;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPrevUUID {
    public string? Path => @"\Segment\Info\PrevUUID";
    public long? Id => 0x3CB923;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPrevFilename {
    public string? Path => @"\Segment\Info\PrevFilename";
    public long? Id => 0x3C83AB;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaNextUUID {
    public string? Path => @"\Segment\Info\NextUUID";
    public long? Id => 0x3EB923;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaNextFilename {
    public string? Path => @"\Segment\Info\NextFilename";
    public long? Id => 0x3E83BB;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSegmentFamily {
    public string? Path => @"\Segment\Info\SegmentFamily";
    public long? Id => 0x4444;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterTranslate {
    public string? Path => @"\Segment\Info\ChapterTranslate";
    public long? Id => 0x6924;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterTranslateID {
    public string? Path => @"\Segment\Info\ChapterTranslate\ChapterTranslateID";
    public long? Id => 0x69A5;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterTranslateCodec {
    public string? Path => @"\Segment\Info\ChapterTranslate\ChapterTranslateCodec";
    public long? Id => 0x69BF;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterTranslateEditionUID {
    public string? Path => @"\Segment\Info\ChapterTranslate\ChapterTranslateEditionUID";
    public long? Id => 0x69FC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTimestampScale {
    public string? Path => @"\Segment\Info\TimestampScale";
    public long? Id => 0x2AD7B1;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaDuration {
    public string? Path => @"\Segment\Info\Duration";
    public long? Id => 0x4489;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaDateUTC {
    public string? Path => @"\Segment\Info\DateUTC";
    public long? Id => 0x4461;
    public string? Type => @"date";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTitle {
    public string? Path => @"\Segment\Info\Title";
    public long? Id => 0x7BA9;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaMuxingApp {
    public string? Path => @"\Segment\Info\MuxingApp";
    public long? Id => 0x4D80;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaWritingApp {
    public string? Path => @"\Segment\Info\WritingApp";
    public long? Id => 0x5741;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCluster {
    public string? Path => @"\Segment\Cluster";
    public long? Id => 0x1F43B675;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTimestamp {
    public string? Path => @"\Segment\Cluster\Timestamp";
    public long? Id => 0xE7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSilentTracks {
    public string? Path => @"\Segment\Cluster\SilentTracks";
    public long? Id => 0x5854;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSilentTrackNumber {
    public string? Path => @"\Segment\Cluster\SilentTracks\SilentTrackNumber";
    public long? Id => 0x58D7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPosition {
    public string? Path => @"\Segment\Cluster\Position";
    public long? Id => 0xA7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPrevSize {
    public string? Path => @"\Segment\Cluster\PrevSize";
    public long? Id => 0xAB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSimpleBlock {
    public string? Path => @"\Segment\Cluster\SimpleBlock";
    public long? Id => 0xA3;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockGroup {
    public string? Path => @"\Segment\Cluster\BlockGroup";
    public long? Id => 0xA0;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlock {
    public string? Path => @"\Segment\Cluster\BlockGroup\Block";
    public long? Id => 0xA1;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockVirtual {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockVirtual";
    public long? Id => 0xA2;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockAdditions {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockAdditions";
    public long? Id => 0x75A1;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockMore {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockAdditions\BlockMore";
    public long? Id => 0xA6;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockAdditional {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockAdditions\BlockMore\BlockAdditional";
    public long? Id => 0xA5;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockAddID {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockAdditions\BlockMore\BlockAddID";
    public long? Id => 0xEE;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockDuration {
    public string? Path => @"\Segment\Cluster\BlockGroup\BlockDuration";
    public long? Id => 0x9B;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaReferencePriority {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferencePriority";
    public long? Id => 0xFA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaReferenceBlock {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferenceBlock";
    public long? Id => 0xFB;
    public string? Type => @"integer";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaReferenceVirtual {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferenceVirtual";
    public long? Id => 0xFD;
    public string? Type => @"integer";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCodecState {
    public string? Path => @"\Segment\Cluster\BlockGroup\CodecState";
    public long? Id => 0xA4;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaDiscardPadding {
    public string? Path => @"\Segment\Cluster\BlockGroup\DiscardPadding";
    public long? Id => 0x75A2;
    public string? Type => @"integer";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSlices {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices";
    public long? Id => 0x8E;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTimeSlice {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice";
    public long? Id => 0xE8;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaLaceNumber {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice\LaceNumber";
    public long? Id => 0xCC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFrameNumber {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice\FrameNumber";
    public long? Id => 0xCD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockAdditionID {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice\BlockAdditionID";
    public long? Id => 0xCB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaDelay {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice\Delay";
    public long? Id => 0xCE;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSliceDuration {
    public string? Path => @"\Segment\Cluster\BlockGroup\Slices\TimeSlice\SliceDuration";
    public long? Id => 0xCF;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaReferenceFrame {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferenceFrame";
    public long? Id => 0xC8;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaReferenceOffset {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferenceFrame\ReferenceOffset";
    public long? Id => 0xC9;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaReferenceTimestamp {
    public string? Path => @"\Segment\Cluster\BlockGroup\ReferenceFrame\ReferenceTimestamp";
    public long? Id => 0xCA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEncryptedBlock {
    public string? Path => @"\Segment\Cluster\EncryptedBlock";
    public long? Id => 0xAF;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTracks {
    public string? Path => @"\Segment\Tracks";
    public long? Id => 0x1654AE6B;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackEntry {
    public string? Path => @"\Segment\Tracks\TrackEntry";
    public long? Id => 0xAE;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackNumber {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackNumber";
    public long? Id => 0xD7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackUID {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackUID";
    public long? Id => 0x73C5;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackType {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackType";
    public long? Id => 0x83;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFlagEnabled {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagEnabled";
    public long? Id => 0xB9;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFlagDefault {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagDefault";
    public long? Id => 0x88;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFlagForced {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagForced";
    public long? Id => 0x55AA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFlagHearingImpaired {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagHearingImpaired";
    public long? Id => 0x55AB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFlagVisualImpaired {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagVisualImpaired";
    public long? Id => 0x55AC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFlagTextDescriptions {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagTextDescriptions";
    public long? Id => 0x55AD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFlagOriginal {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagOriginal";
    public long? Id => 0x55AE;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFlagCommentary {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagCommentary";
    public long? Id => 0x55AF;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFlagLacing {
    public string? Path => @"\Segment\Tracks\TrackEntry\FlagLacing";
    public long? Id => 0x9C;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaMinCache {
    public string? Path => @"\Segment\Tracks\TrackEntry\MinCache";
    public long? Id => 0x6DE7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaMaxCache {
    public string? Path => @"\Segment\Tracks\TrackEntry\MaxCache";
    public long? Id => 0x6DF8;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaDefaultDuration {
    public string? Path => @"\Segment\Tracks\TrackEntry\DefaultDuration";
    public long? Id => 0x23E383;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaDefaultDecodedFieldDuration {
    public string? Path => @"\Segment\Tracks\TrackEntry\DefaultDecodedFieldDuration";
    public long? Id => 0x234E7A;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackTimestampScale {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackTimestampScale";
    public long? Id => 0x23314F;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackOffset {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOffset";
    public long? Id => 0x537F;
    public string? Type => @"integer";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaMaxBlockAdditionID {
    public string? Path => @"\Segment\Tracks\TrackEntry\MaxBlockAdditionID";
    public long? Id => 0x55EE;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockAdditionMapping {
    public string? Path => @"\Segment\Tracks\TrackEntry\BlockAdditionMapping";
    public long? Id => 0x41E4;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockAddIDValue {
    public string? Path => @"\Segment\Tracks\TrackEntry\BlockAdditionMapping\BlockAddIDValue";
    public long? Id => 0x41F0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockAddIDName {
    public string? Path => @"\Segment\Tracks\TrackEntry\BlockAdditionMapping\BlockAddIDName";
    public long? Id => 0x41A4;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockAddIDType {
    public string? Path => @"\Segment\Tracks\TrackEntry\BlockAdditionMapping\BlockAddIDType";
    public long? Id => 0x41E7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBlockAddIDExtraData {
    public string? Path => @"\Segment\Tracks\TrackEntry\BlockAdditionMapping\BlockAddIDExtraData";
    public long? Id => 0x41ED;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaName {
    public string? Path => @"\Segment\Tracks\TrackEntry\Name";
    public long? Id => 0x536E;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaLanguage {
    public string? Path => @"\Segment\Tracks\TrackEntry\Language";
    public long? Id => 0x22B59C;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaLanguageBCP47 {
    public string? Path => @"\Segment\Tracks\TrackEntry\LanguageBCP47";
    public long? Id => 0x22B59D;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCodecID {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecID";
    public long? Id => 0x86;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCodecPrivate {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecPrivate";
    public long? Id => 0x63A2;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCodecName {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecName";
    public long? Id => 0x258688;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaAttachmentLink {
    public string? Path => @"\Segment\Tracks\TrackEntry\AttachmentLink";
    public long? Id => 0x7446;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCodecSettings {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecSettings";
    public long? Id => 0x3A9697;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCodecInfoURL {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecInfoURL";
    public long? Id => 0x3B4040;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCodecDownloadURL {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecDownloadURL";
    public long? Id => 0x26B240;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCodecDecodeAll {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecDecodeAll";
    public long? Id => 0xAA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackOverlay {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOverlay";
    public long? Id => 0x6FAB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCodecDelay {
    public string? Path => @"\Segment\Tracks\TrackEntry\CodecDelay";
    public long? Id => 0x56AA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSeekPreRoll {
    public string? Path => @"\Segment\Tracks\TrackEntry\SeekPreRoll";
    public long? Id => 0x56BB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackTranslate {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackTranslate";
    public long? Id => 0x6624;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackTranslateTrackID {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackTranslate\TrackTranslateTrackID";
    public long? Id => 0x66A5;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackTranslateCodec {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackTranslate\TrackTranslateCodec";
    public long? Id => 0x66BF;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackTranslateEditionUID {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackTranslate\TrackTranslateEditionUID";
    public long? Id => 0x66FC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaVideo {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video";
    public long? Id => 0xE0;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFlagInterlaced {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\FlagInterlaced";
    public long? Id => 0x9A;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFieldOrder {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\FieldOrder";
    public long? Id => 0x9D;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaStereoMode {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\StereoMode";
    public long? Id => 0x53B8;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaAlphaMode {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\AlphaMode";
    public long? Id => 0x53C0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaOldStereoMode {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\OldStereoMode";
    public long? Id => 0x53B9;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPixelWidth {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelWidth";
    public long? Id => 0xB0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPixelHeight {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelHeight";
    public long? Id => 0xBA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPixelCropBottom {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelCropBottom";
    public long? Id => 0x54AA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPixelCropTop {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelCropTop";
    public long? Id => 0x54BB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPixelCropLeft {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelCropLeft";
    public long? Id => 0x54CC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPixelCropRight {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\PixelCropRight";
    public long? Id => 0x54DD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaDisplayWidth {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\DisplayWidth";
    public long? Id => 0x54B0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaDisplayHeight {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\DisplayHeight";
    public long? Id => 0x54BA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaDisplayUnit {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\DisplayUnit";
    public long? Id => 0x54B2;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaAspectRatioType {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\AspectRatioType";
    public long? Id => 0x54B3;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaUncompressedFourCC {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\UncompressedFourCC";
    public long? Id => 0x2EB524;
    public string? Type => @"binary";
    public string? Length => @"4";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaGammaValue {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\GammaValue";
    public long? Id => 0x2FB523;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFrameRate {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\FrameRate";
    public long? Id => 0x2383E3;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaColour {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour";
    public long? Id => 0x55B0;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaMatrixCoefficients {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MatrixCoefficients";
    public long? Id => 0x55B1;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBitsPerChannel {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\BitsPerChannel";
    public long? Id => 0x55B2;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChromaSubsamplingHorz {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\ChromaSubsamplingHorz";
    public long? Id => 0x55B3;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChromaSubsamplingVert {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\ChromaSubsamplingVert";
    public long? Id => 0x55B4;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCbSubsamplingHorz {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\CbSubsamplingHorz";
    public long? Id => 0x55B5;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCbSubsamplingVert {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\CbSubsamplingVert";
    public long? Id => 0x55B6;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChromaSitingHorz {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\ChromaSitingHorz";
    public long? Id => 0x55B7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChromaSitingVert {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\ChromaSitingVert";
    public long? Id => 0x55B8;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaRange {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\Range";
    public long? Id => 0x55B9;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTransferCharacteristics {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\TransferCharacteristics";
    public long? Id => 0x55BA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPrimaries {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\Primaries";
    public long? Id => 0x55BB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaMaxCLL {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MaxCLL";
    public long? Id => 0x55BC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaMaxFALL {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MaxFALL";
    public long? Id => 0x55BD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaMasteringMetadata {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata";
    public long? Id => 0x55D0;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPrimaryRChromaticityX {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryRChromaticityX";
    public long? Id => 0x55D1;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPrimaryRChromaticityY {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryRChromaticityY";
    public long? Id => 0x55D2;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPrimaryGChromaticityX {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryGChromaticityX";
    public long? Id => 0x55D3;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPrimaryGChromaticityY {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryGChromaticityY";
    public long? Id => 0x55D4;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPrimaryBChromaticityX {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryBChromaticityX";
    public long? Id => 0x55D5;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaPrimaryBChromaticityY {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\PrimaryBChromaticityY";
    public long? Id => 0x55D6;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaWhitePointChromaticityX {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\WhitePointChromaticityX";
    public long? Id => 0x55D7;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaWhitePointChromaticityY {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\WhitePointChromaticityY";
    public long? Id => 0x55D8;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaLuminanceMax {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\LuminanceMax";
    public long? Id => 0x55D9;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaLuminanceMin {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Colour\MasteringMetadata\LuminanceMin";
    public long? Id => 0x55DA;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaProjection {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection";
    public long? Id => 0x7670;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaProjectionType {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection\ProjectionType";
    public long? Id => 0x7671;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaProjectionPrivate {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection\ProjectionPrivate";
    public long? Id => 0x7672;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaProjectionPoseYaw {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection\ProjectionPoseYaw";
    public long? Id => 0x7673;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaProjectionPosePitch {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection\ProjectionPosePitch";
    public long? Id => 0x7674;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaProjectionPoseRoll {
    public string? Path => @"\Segment\Tracks\TrackEntry\Video\Projection\ProjectionPoseRoll";
    public long? Id => 0x7675;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaAudio {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio";
    public long? Id => 0xE1;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSamplingFrequency {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\SamplingFrequency";
    public long? Id => 0xB5;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaOutputSamplingFrequency {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\OutputSamplingFrequency";
    public long? Id => 0x78B5;
    public string? Type => @"float";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChannels {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\Channels";
    public long? Id => 0x9F;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChannelPositions {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\ChannelPositions";
    public long? Id => 0x7D7B;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaBitDepth {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\BitDepth";
    public long? Id => 0x6264;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEmphasis {
    public string? Path => @"\Segment\Tracks\TrackEntry\Audio\Emphasis";
    public long? Id => 0x52F1;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackOperation {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation";
    public long? Id => 0xE2;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackCombinePlanes {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackCombinePlanes";
    public long? Id => 0xE3;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackPlane {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackCombinePlanes\TrackPlane";
    public long? Id => 0xE4;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackPlaneUID {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackCombinePlanes\TrackPlane\TrackPlaneUID";
    public long? Id => 0xE5;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackPlaneType {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackCombinePlanes\TrackPlane\TrackPlaneType";
    public long? Id => 0xE6;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackJoinBlocks {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackJoinBlocks";
    public long? Id => 0xE9;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrackJoinUID {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrackOperation\TrackJoinBlocks\TrackJoinUID";
    public long? Id => 0xED;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrickTrackUID {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrickTrackUID";
    public long? Id => 0xC0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrickTrackSegmentUID {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrickTrackSegmentUID";
    public long? Id => 0xC1;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrickTrackFlag {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrickTrackFlag";
    public long? Id => 0xC6;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrickMasterTrackUID {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrickMasterTrackUID";
    public long? Id => 0xC7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTrickMasterTrackSegmentUID {
    public string? Path => @"\Segment\Tracks\TrackEntry\TrickMasterTrackSegmentUID";
    public long? Id => 0xC4;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentEncodings {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings";
    public long? Id => 0x6D80;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentEncoding {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding";
    public long? Id => 0x6240;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentEncodingOrder {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncodingOrder";
    public long? Id => 0x5031;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentEncodingScope {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncodingScope";
    public long? Id => 0x5032;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentEncodingType {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncodingType";
    public long? Id => 0x5033;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentCompression {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentCompression";
    public long? Id => 0x5034;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentCompAlgo {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentCompression\ContentCompAlgo";
    public long? Id => 0x4254;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentCompSettings {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentCompression\ContentCompSettings";
    public long? Id => 0x4255;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentEncryption {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption";
    public long? Id => 0x5035;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentEncAlgo {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentEncAlgo";
    public long? Id => 0x47E1;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentEncKeyID {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentEncKeyID";
    public long? Id => 0x47E2;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentEncAESSettings {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentEncAESSettings";
    public long? Id => 0x47E7;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaAESSettingsCipherMode {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentEncAESSettings\AESSettingsCipherMode";
    public long? Id => 0x47E8;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentSignature {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentSignature";
    public long? Id => 0x47E3;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentSigKeyID {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentSigKeyID";
    public long? Id => 0x47E4;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentSigAlgo {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentSigAlgo";
    public long? Id => 0x47E5;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaContentSigHashAlgo {
    public string? Path => @"\Segment\Tracks\TrackEntry\ContentEncodings\ContentEncoding\ContentEncryption\ContentSigHashAlgo";
    public long? Id => 0x47E6;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCues {
    public string? Path => @"\Segment\Cues";
    public long? Id => 0x1C53BB6B;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCuePoint {
    public string? Path => @"\Segment\Cues\CuePoint";
    public long? Id => 0xBB;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueTime {
    public string? Path => @"\Segment\Cues\CuePoint\CueTime";
    public long? Id => 0xB3;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueTrackPositions {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions";
    public long? Id => 0xB7;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueTrack {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueTrack";
    public long? Id => 0xF7;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueClusterPosition {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueClusterPosition";
    public long? Id => 0xF1;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueRelativePosition {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueRelativePosition";
    public long? Id => 0xF0;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueDuration {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueDuration";
    public long? Id => 0xB2;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueBlockNumber {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueBlockNumber";
    public long? Id => 0x5378;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueCodecState {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueCodecState";
    public long? Id => 0xEA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueReference {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueReference";
    public long? Id => 0xDB;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueRefTime {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueReference\CueRefTime";
    public long? Id => 0x96;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueRefCluster {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueReference\CueRefCluster";
    public long? Id => 0x97;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueRefNumber {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueReference\CueRefNumber";
    public long? Id => 0x535F;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaCueRefCodecState {
    public string? Path => @"\Segment\Cues\CuePoint\CueTrackPositions\CueReference\CueRefCodecState";
    public long? Id => 0xEB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaAttachments {
    public string? Path => @"\Segment\Attachments";
    public long? Id => 0x1941A469;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaAttachedFile {
    public string? Path => @"\Segment\Attachments\AttachedFile";
    public long? Id => 0x61A7;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFileDescription {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileDescription";
    public long? Id => 0x467E;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFileName {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileName";
    public long? Id => 0x466E;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFileMediaType {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileMediaType";
    public long? Id => 0x4660;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFileData {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileData";
    public long? Id => 0x465C;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFileUID {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileUID";
    public long? Id => 0x46AE;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFileReferral {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileReferral";
    public long? Id => 0x4675;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFileUsedStartTime {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileUsedStartTime";
    public long? Id => 0x4661;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaFileUsedEndTime {
    public string? Path => @"\Segment\Attachments\AttachedFile\FileUsedEndTime";
    public long? Id => 0x4662;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapters {
    public string? Path => @"\Segment\Chapters";
    public long? Id => 0x1043A770;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEditionEntry {
    public string? Path => @"\Segment\Chapters\EditionEntry";
    public long? Id => 0x45B9;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEditionUID {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionUID";
    public long? Id => 0x45BC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEditionFlagHidden {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionFlagHidden";
    public long? Id => 0x45BD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEditionFlagDefault {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionFlagDefault";
    public long? Id => 0x45DB;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEditionFlagOrdered {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionFlagOrdered";
    public long? Id => 0x45DD;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEditionDisplay {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionDisplay";
    public long? Id => 0x4520;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEditionString {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionDisplay\EditionString";
    public long? Id => 0x4521;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaEditionLanguageIETF {
    public string? Path => @"\Segment\Chapters\EditionEntry\EditionDisplay\EditionLanguageIETF";
    public long? Id => 0x45E4;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterAtom {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom";
    public long? Id => 0xB6;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterUID {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterUID";
    public long? Id => 0x73C4;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterStringUID {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterStringUID";
    public long? Id => 0x5654;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterTimeStart {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterTimeStart";
    public long? Id => 0x91;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterTimeEnd {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterTimeEnd";
    public long? Id => 0x92;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterFlagHidden {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterFlagHidden";
    public long? Id => 0x98;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterFlagEnabled {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterFlagEnabled";
    public long? Id => 0x4598;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterSegmentUUID {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterSegmentUUID";
    public long? Id => 0x6E67;
    public string? Type => @"binary";
    public string? Length => @"16";
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterSkipType {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterSkipType";
    public long? Id => 0x4588;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterSegmentEditionUID {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterSegmentEditionUID";
    public long? Id => 0x6EBC;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterPhysicalEquiv {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterPhysicalEquiv";
    public long? Id => 0x63C3;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterTrack {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterTrack";
    public long? Id => 0x8F;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterTrackUID {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterTrack\ChapterTrackUID";
    public long? Id => 0x89;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapterDisplay {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterDisplay";
    public long? Id => 0x80;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapString {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterDisplay\ChapString";
    public long? Id => 0x85;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapLanguage {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterDisplay\ChapLanguage";
    public long? Id => 0x437C;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapLanguageBCP47 {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterDisplay\ChapLanguageBCP47";
    public long? Id => 0x437D;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapCountry {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapterDisplay\ChapCountry";
    public long? Id => 0x437E;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapProcess {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess";
    public long? Id => 0x6944;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapProcessCodecID {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess\ChapProcessCodecID";
    public long? Id => 0x6955;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapProcessPrivate {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess\ChapProcessPrivate";
    public long? Id => 0x450D;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapProcessCommand {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess\ChapProcessCommand";
    public long? Id => 0x6911;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapProcessTime {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess\ChapProcessCommand\ChapProcessTime";
    public long? Id => 0x6922;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaChapProcessData {
    public string? Path => @"\Segment\Chapters\EditionEntry\+ChapterAtom\ChapProcess\ChapProcessCommand\ChapProcessData";
    public long? Id => 0x6933;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTags {
    public string? Path => @"\Segment\Tags";
    public long? Id => 0x1254C367;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTag {
    public string? Path => @"\Segment\Tags\Tag";
    public long? Id => 0x7373;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTargets {
    public string? Path => @"\Segment\Tags\Tag\Targets";
    public long? Id => 0x63C0;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTargetTypeValue {
    public string? Path => @"\Segment\Tags\Tag\Targets\TargetTypeValue";
    public long? Id => 0x68CA;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTargetType {
    public string? Path => @"\Segment\Tags\Tag\Targets\TargetType";
    public long? Id => 0x63CA;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagTrackUID {
    public string? Path => @"\Segment\Tags\Tag\Targets\TagTrackUID";
    public long? Id => 0x63C5;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagEditionUID {
    public string? Path => @"\Segment\Tags\Tag\Targets\TagEditionUID";
    public long? Id => 0x63C9;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagChapterUID {
    public string? Path => @"\Segment\Tags\Tag\Targets\TagChapterUID";
    public long? Id => 0x63C4;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagAttachmentUID {
    public string? Path => @"\Segment\Tags\Tag\Targets\TagAttachmentUID";
    public long? Id => 0x63C6;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaSimpleTag {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag";
    public long? Id => 0x67C8;
    public string? Type => @"master";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => null;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagName {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagName";
    public long? Id => 0x45A3;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagLanguage {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagLanguage";
    public long? Id => 0x447A;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagLanguageBCP47 {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagLanguageBCP47";
    public long? Id => 0x447B;
    public string? Type => @"string";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagDefault {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagDefault";
    public long? Id => 0x4484;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagDefaultBogus {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagDefaultBogus";
    public long? Id => 0x44B4;
    public string? Type => @"uinteger";
    public string? Length => null;
    public int? MinOccurs => 1;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagString {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagString";
    public long? Id => 0x4487;
    public string? Type => @"utf-8";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}

/// <summary>
/// The Root Element that contains all other Top-Level Elements; see (#data-layout).
/// </summary>
public class MatroskaTagBinary {
    public string? Path => @"\Segment\Tags\Tag\+SimpleTag\TagBinary";
    public long? Id => 0x4485;
    public string? Type => @"binary";
    public string? Length => null;
    public int? MinOccurs => null;
    public int? MaxOccurs => 1;
}
