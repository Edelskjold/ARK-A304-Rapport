modelBuilder.Entity<LongTripForm>()
	.HasRequired(ltf => ltf.ResponsibleMember)
	.WithMany()
	.HasForeignKey(ltf => ltf.ResponsibleMemberId)
	.WillCascadeOnDelete(false);