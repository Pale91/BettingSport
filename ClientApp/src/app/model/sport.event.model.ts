export interface SportEvent {
    id: number;
    name: string;
    oddsForFirstTeam?: number;
    oddsForDraw?: number;
    oddsForSecondTeam?: number;
    startDate: Date;
}
