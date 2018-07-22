export default class Helpers  {
    /**
     * Time count down
     * @param date start date for days/hours/minutes/secconds count down
     */
    public static countDown(date: Date): string {
        const startTime: number = new Date(date).getTime();
        const now: number = new Date().getTime();
        const distance: number = startTime - now;

        const days: number = Math.floor(distance / (1000 * 60 * 60 * 24));
        const hours: number = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        const minutes: number = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        const seconds: number = Math.floor((distance % (1000 * 60)) / 1000);

        const result = distance > 0
            ? `${days}d ${hours}h ${minutes}m ${seconds}s`
            : 'endOfAcution';
        return result;
    }
}
