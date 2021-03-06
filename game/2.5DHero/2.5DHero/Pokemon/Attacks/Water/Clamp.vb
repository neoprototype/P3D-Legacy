Namespace BattleSystem.Moves.Water

    Public Class Clamp

        Inherits Attack

        Public Sub New()
            '#Definitions
            Me.Type = New Element(Element.Types.Water)
            Me.ID = 128
            Me.OriginalPP = 10
            Me.CurrentPP = 10
            Me.MaxPP = 10
            Me.Power = 35
            Me.Accuracy = 85
            Me.Category = Categories.Physical
            Me.ContestCategory = ContestCategories.Tough
            Me.Name = "Clamp"
            Me.Description = "The target is clamped and squeezed by the user's very thick and sturdy shell for four to five turns."
            Me.CriticalChance = 1
            Me.IsHMMove = False
            Me.Target = Targets.OneAdjacentTarget
            Me.Priority = 0
            Me.TimesToAttack = 1
            '#End

            '#SpecialDefinitions
            Me.MakesContact = True
            Me.ProtectAffected = True
            Me.MagicCoatAffected = False
            Me.SnatchAffected = False
            Me.MirrorMoveAffected = True
            Me.KingsrockAffected = True
            Me.CounterAffected = True

            Me.DisabledWhileGravity = False
            Me.UseEffectiveness = True
            Me.ImmunityAffected = True
            Me.HasSecondaryEffect = False
            Me.RemovesFrozen = False

            Me.IsHealingMove = False
            Me.IsRecoilMove = False
            Me.IsPunchingMove = False
            Me.IsDamagingMove = True
            Me.IsProtectMove = False
            Me.IsSoundMove = False

            Me.IsAffectedBySubstitute = True
            Me.IsOneHitKOMove = False
            Me.IsWonderGuardAffected = True
            '#End

            Me.AIField1 = AIField.Damage
            Me.AIField2 = AIField.Trap
        End Sub

        Public Overrides Sub MoveHits(own As Boolean, BattleScreen As BattleScreen)
            Dim p As Pokemon = BattleScreen.OwnPokemon
            Dim op As Pokemon = BattleScreen.OppPokemon
            If own = False Then
                p = BattleScreen.OppPokemon
                op = BattleScreen.OwnPokemon
            End If

            Dim turns As Integer = 4
            If Core.Random.Next(0, 100) < 50 Then
                turns = 5
            End If

            If Not p.Item Is Nothing Then
                If p.Item.Name.ToLower() = "grip claw" And BattleScreen.FieldEffects.CanUseItem(own) = True And BattleScreen.FieldEffects.CanUseOwnItem(own, BattleScreen) = True Then
                    turns = 5
                End If
            End If

            If own = True Then
                If BattleScreen.FieldEffects.OppClamp = 0 Then
                    BattleScreen.FieldEffects.OppClamp = turns
                    BattleScreen.BattleQuery.Add(New TextQueryObject(p.GetDisplayName() & " clamped " & op.GetDisplayName() & "!"))
                End If
            Else
                If BattleScreen.FieldEffects.OwnClamp = 0 Then
                    BattleScreen.FieldEffects.OwnClamp = turns
                    BattleScreen.BattleQuery.Add(New TextQueryObject(p.GetDisplayName() & " clamped " & op.GetDisplayName() & "!"))
                End If
            End If
        End Sub

    End Class

End Namespace