import { Injectable } from "@angular/core";

declare const qrcode: any;

@Injectable()
export class QrCodeService {

    constructor() {
        //
    }

    // https://kazuhikoarase.github.io/qrcode-generator/js/demo/
    createImgTag = function (text, typeNumber, errorCorrectionLevel, mode, mb) {
        mb = mb || 'UTF-8';
        mode = mode || 'Byte'
        qrcode.stringToBytes = qrcode.stringToBytesFuncs[mb];
        var qr = qrcode(typeNumber || 4, errorCorrectionLevel || 'M');
        qr.addData(text, mode);
        qr.make();
        //  return qr.createTableTag();
        //  return qr.createSvgTag();
        return qr.createImgTag();
    };

}