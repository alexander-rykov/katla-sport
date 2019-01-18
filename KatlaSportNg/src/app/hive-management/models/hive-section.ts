export class HiveSection {
    constructor(
        public id : number,
        public name : string,
        public code : string,
        public storeHiveId : number,
        public isDeleted : boolean,
        public lastUpdated : string
    ) { }
}
