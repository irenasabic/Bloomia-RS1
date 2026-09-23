export interface AppointmentNotificationLogDto {
  id: number;
  appointmentId: number;
  recipientEmail: string;
  notificationType: string;
  status: string;
  createdAtUtc: string;
  sentAtUtc: string | null;
  errorMessage: string | null;
  clientName: string;
  therapistName: string;
  scheduledAtUtc: string;
  sessionType: string;
}